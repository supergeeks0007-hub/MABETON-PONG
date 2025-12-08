using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;

    // Último player que tocou na bola
    private player lastPlayerHit;

    // Posição inicial da bola
    private Vector3 startPosition;

    // 🎵 Áudio da colisão (arraste no Inspector)
    [SerializeField] private AudioClip bounceSound;
    private AudioSource audioSource;

    public player GetLastPlayerHit() => lastPlayerHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Cria um AudioSource automaticamente
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = bounceSound;

        // Salva posição inicial
        startPosition = transform.position;

        LaunchBall();
    }

    private void LaunchBall()
    {
        bool dir = Random.value >= 0.5f;
        float yVelocity = Random.Range(-1f, 1f);
        float xVelocity = dir ? 1f : -1f;

        rb.linearVelocity = new Vector2(xVelocity * speed, yVelocity * speed);
    }

    private void ResetBall()
    {
        transform.position = startPosition;
        rb.linearVelocity = Vector2.zero;

        LaunchBall();
    }

    private void PlayBounceSound()
    {
        if (bounceSound != null)
            audioSource.PlayOneShot(bounceSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sempre toca o som na colisão
        PlayBounceSound();

        // Se colidiu com player
        player p = collision.collider.GetComponent<player>();
        if (p != null)
        {
            lastPlayerHit = p;
            return;
        }

        // Se colidiu com bloco
        Brick brick = collision.collider.GetComponent<Brick>();
        if (brick != null)
        {
            brick.TryBreak(lastPlayerHit);
            return;
        }

        // Se colidiu com Offset (saiu da tela)
        if (collision.collider.CompareTag("Offset"))
        {
            ResetBall();
        }
    }
}
