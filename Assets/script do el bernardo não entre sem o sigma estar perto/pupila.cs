using UnityEngine;

public class pupila : MonoBehaviour
{
    [SerializeField] Transform eyeCenter; // centro do olho (parte branca)
    [SerializeField] Transform ball;      // referência da bola (prefab instanciado)
    [SerializeField] float maxDistance = 0.10f; // quão longe a pupila pode andar

    private void LateUpdate()
    {
        if (eyeCenter == null || ball == null)
            return;

        // direção que a pupila deve olhar
        Vector2 direction = (ball.position - eyeCenter.position).normalized;

        // posição dentro do limite do olho
        Vector2 targetPos = (Vector2)eyeCenter.position + direction * maxDistance;

        // move a pupila
        transform.position = targetPos;
    }
}
