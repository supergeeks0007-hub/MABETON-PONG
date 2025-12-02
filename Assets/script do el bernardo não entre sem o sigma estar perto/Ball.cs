using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;

    // 1️⃣ Último jogador que tocou na bola
    private player lastPlayerHit;

    public player GetLastPlayerHit() => lastPlayerHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        bool dir = Random.value >= 0.5f;
        float yVelocity = Random.Range(-1f, 1f);
        float xVelocity = dir ? 1f : -1f;

        rb.linearVelocity = new Vector2(xVelocity * speed, yVelocity * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 2️⃣ Se colidir com player, salva quem bateu
        player p = collision.collider.GetComponent<player>();
        if (p != null)
        {
            lastPlayerHit = p;
            return;
        }

        // 3️⃣ Se colidir com bloco, tenta destruí-lo
        Brick brick = collision.collider.GetComponent<Brick>();
        if (brick != null)
        {
            brick.TryBreak(lastPlayerHit);
        }
    }
}