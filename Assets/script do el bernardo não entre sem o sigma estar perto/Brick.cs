using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameManager manager;

    // 1️⃣ Dono do bloco
    public player.PlayerSide brickOwner;

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

    // 2️⃣ Função nova: verifica se pode quebrar
    public void TryBreak(player whoHit)
    {
        // Se ninguém bateu na bola ainda → não destruir
        if (whoHit == null)
            return;

        // 3️⃣ Se quem bateu é o DONO do bloco → não destruir
        if (whoHit.GetPlayerSide() == brickOwner)
        {
            // É o dono, então não destrói
            return;
        }

        // 4️⃣ Caso contrário, quem bateu é o adversário → marcar ponto + destruir
        manager.AddScore(whoHit.GetPlayerSide());

        Destroy(gameObject);
    }
}
