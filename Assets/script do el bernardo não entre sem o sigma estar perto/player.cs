using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]
public class player : MonoBehaviour
{
    public enum PlayerSide { Player1, Player2 }

    [Header("Player Settings")]
    [SerializeField] PlayerSide playerSide = PlayerSide.Player1;
    [SerializeField, Tooltip("Velocidade de movimento em unidades por segundo")]
    private float moveSpeed = 10f;

    [Header("Input")]
    [SerializeField, Tooltip("Asset gerado do Input System (PlayerControls)")]
    private PlayerInput playerInput; // vinculado automaticamente se PlayerInput está no mesmo GameObject

    [SerializeField, Tooltip("Nome da ação de movimento (precisa ser Vector2)")]
    private string moveActionName = "Move";

    private Rigidbody2D rb;
    private InputAction moveAction;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Se não houver PlayerInput no mesmo GameObject, tente encontrar
        if (playerInput == null)
        {
            playerInput = GetComponent<PlayerInput>();
            if (playerInput == null)
            {
                Debug.LogError("PlayerInput não encontrado! Adicione um componente PlayerInput ao jogador.");
                enabled = false;
                return;
            }
        }

        // Vincula a ação de movimento dinamicamente
        moveAction = playerInput.actions[moveActionName];
    }

    private void OnEnable()
    {
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 move = moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    /// <summary>
    /// Define quem é o jogador (1 ou 2) — pode ser feito via código ou no Inspector.
    /// </summary>
    public void SetPlayerSide(PlayerSide side)
    {
        playerSide = side;
    }

    public PlayerSide GetPlayerSide() => playerSide;
}

