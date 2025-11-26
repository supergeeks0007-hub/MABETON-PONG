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

        var p = playerInput.GetComponent<player>();

        if (playerCount == 1)
        {
            playerInput.transform.position = leftSpawn.position;
            p.SetPlayerSide(player.PlayerSide.Player1);
            playerInput.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (playerCount == 2)
        {
            playerInput.transform.position = rightSpawn.position;
            p.SetPlayerSide(player.PlayerSide.Player2);
            playerInput.transform.localScale = new Vector3(-1, 1, 1); // espelha no X
        }
    }

}
