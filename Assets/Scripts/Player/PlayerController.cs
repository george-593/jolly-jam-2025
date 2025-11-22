using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float health = 100f;
    public Camera camera;
    public Weapon weapon;

    private Rigidbody2D rb;
    private Vector2 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInputs();
    }
    void FixedUpdate()
    {
        // Make player follow mouse
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDir = mousePos - rb.position;
        float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    void ProcessInputs()
    {
        // Movement
        float hzInput = Input.GetAxis("Horizontal");
        float vtInput = Input.GetAxis("Vertical");

        rb.linearVelocity = new Vector2(moveSpeed * hzInput, moveSpeed * vtInput);

        // Shooting
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
    }
}
