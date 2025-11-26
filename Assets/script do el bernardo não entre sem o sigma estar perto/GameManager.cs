using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int player1Score = 0;
    private int player2Score = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(player.PlayerSide side, int amount)
    {
        if (side == player.PlayerSide.Player1)
            player1Score += amount;
        else
            player2Score += amount;

        Debug.Log($"P1: {player1Score} | P2: {player2Score}");
    }
}
