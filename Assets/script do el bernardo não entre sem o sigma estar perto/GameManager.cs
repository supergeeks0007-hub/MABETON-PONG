using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int player1Score = 0;
    private int player2Score = 0;

    [Header("UI")]
    public TextMeshProUGUI p1;
    public TextMeshProUGUI p2;
    public TextMeshProUGUI winText;

    public GameObject winCanva;
    public GameObject ball;

    private bool gameEnded = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        winCanva.SetActive(false);
    }

    private void Update()
    {
        p1.text = player1Score.ToString();
        p2.text = player2Score.ToString();

        if (!gameEnded && (player1Score == 10 || player2Score == 10))
        {
            gameEnded = true;
            EndGame(player1Score == 10 ? "Player 1 ganhou!" : "Player 2 ganhou!");
        }
    }

    public void AddScore(player.PlayerSide side)
    {
        if (side == player.PlayerSide.Player1)
            player1Score += 1;
        else
            player2Score += 1;

        Debug.Log($"P1: {player1Score} | P2: {player2Score}");
    }

    private void EndGame(string winnerMessage)
    {
        // Remove a bola
        if (ball != null)
            Destroy(ball);

        // Exibe quem ganhou
        winText.text = winnerMessage;
        winCanva.SetActive(true);

        // Inicia sequência de reset
        StartCoroutine(RestartSequence());
    }

    private IEnumerator RestartSequence()
    {
        // Espera inicial de 3 segundos
        yield return new WaitForSeconds(5f);

        // Agora ativa o texto do contador
        for (int i = 5; i > 0; i--)
        {
            winText.text = $"O jogo recomeçará em {i}";
            yield return new WaitForSeconds(1f);
        }

        // Reinicia a cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
