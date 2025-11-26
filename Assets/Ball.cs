using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    // Start is called before the first frame updete

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Moverbola();
    }
    private void Moverbola()
    {
        rb.linearVelocity = new Vector2(speed, speed);
    }

}