using UnityEngine;

public class Brick : MonoBehaviour
{
    public int points = 1;
    public GameManager manager;

    private void Start()
    {
        // Se não tiver GameManager arrastado no Inspector, tenta achar na cena
        if (manager == null)
        {
            manager = FindObjectOfType<GameManager>();

            if (manager == null)
            {
                Debug.LogError("GameManager não encontrado na cena! Adicione um GameManager.");
            }
        }
    }

    public void Hit(player whoHit)
{
    if (manager != null && whoHit != null)
    {
        manager.AddScore(whoHit.GetPlayerSide(), points);
    }

    Destroy(gameObject);
}
}
