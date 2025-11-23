using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 5f;
    public float health = 100f;
    public float maxHealth = 100f;
    public float healthRegenRate = .5f;
    public float healthRegenSeconds = 2.5f;
    public Weapon weapon;
    public Camera mainCamera;

    [Header("Warmth Settings")]
    public float warmth = 100f;
    public float maxWarmth = 100f;
    public float warmthDecrement = 1f; // Amount to lower the health by per wamrth decrement time
    public float wamrthDecreaseTime = 5f;

    [Header("UI Settings")]
    public Slider healthBar;
    public Slider warmthBar;

    private Rigidbody2D rb;
    private Vector2 mousePos;
    private float timeSinceLastWarmthDecrease = 0f;
    private float timeSinceLastHPRegen = 0f;


    public void AddWarmth(float warmthAmount)
    {
        warmth += warmthAmount;
        if (warmth > maxWarmth) warmth = maxWarmth;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInputs();
        UpdateUI();

        // Death check
        if (health <= 0 || warmth <= 0)
        {
            Debug.Log("Player dead (not implemented)");
        }

        // Warmth decrement
        timeSinceLastWarmthDecrease += Time.deltaTime;
        if (timeSinceLastWarmthDecrease >= wamrthDecreaseTime)
        {
            warmth -= warmthDecrement;
            timeSinceLastWarmthDecrease = 0f;

        }

        // HP Regen
        timeSinceLastHPRegen += Time.deltaTime;
        if (timeSinceLastHPRegen >= healthRegenSeconds)
        {
            timeSinceLastHPRegen = 0;
            health += healthRegenRate;
        }

    }
    void FixedUpdate()
    {
        // Make player follow mouse
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
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

    void UpdateUI()
    {
        healthBar.value = health;
        warmthBar.value = warmth;

        healthBar.maxValue = maxHealth;
        warmthBar.maxValue = maxWarmth;
    }
}
