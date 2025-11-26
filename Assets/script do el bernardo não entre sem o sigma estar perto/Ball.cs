using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public int speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bool dir = Random.value >= 0.5 ? true : false;
        float yVelocity = Random.Range(-1f, 1f);
        float xVelocity;
        if (dir)
        {
            xVelocity = 1f;
        }
        else
        {
            xVelocity = -1f;
        }

        rb.linearVelocity = new Vector2(xVelocity * speed, yVelocity * speed);
    }
}