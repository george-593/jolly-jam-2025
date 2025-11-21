using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float health = 100f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement
        float hzInput = Input.GetAxis("Horizontal");
        float vtInput = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(moveSpeed * hzInput, moveSpeed * vtInput);
    }
}
