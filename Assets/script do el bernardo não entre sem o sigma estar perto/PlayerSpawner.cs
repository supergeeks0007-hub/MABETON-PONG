using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] Transform leftSpawn;
    [SerializeField] Transform rightSpawn;

    private int playerCount = 0;

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        playerCount++;

        // Define lado e posição
        if (playerCount == 1)
        {
            playerInput.transform.position = leftSpawn.position;
            playerInput.GetComponent<player>().SetPlayerSide(player.PlayerSide.Player1);
        }
        else if (playerCount == 2)
        {
            playerInput.transform.position = rightSpawn.position;
            playerInput.GetComponent<player>().SetPlayerSide(player.PlayerSide.Player2);
        }
    }
}
