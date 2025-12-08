using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameManager manager;

    // Dono do bloco
    public player.PlayerSide brickOwner;

    // 🎵 Som da quebra
    [SerializeField] private AudioClip breakSound;

    private void Start()
    {
        if (manager == null)
        {
            manager = FindFirstObjectByType<GameManager>();

            if (manager == null)
            {
                Debug.LogError("GameManager não encontrado na cena!");
            }
        }
    }

    public void TryBreak(player whoHit)
    {
        if (whoHit == null)
            return;

        if (whoHit.GetPlayerSide() == brickOwner)
            return;

        // Marca ponto
        manager.AddScore(whoHit.GetPlayerSide());

        // 🎵 Toca som separado do objeto
        if (breakSound != null)
            AudioSource.PlayClipAtPoint(breakSound, transform.position);

        // ❗ Destruir imediatamente
        Destroy(gameObject);
    }
}
