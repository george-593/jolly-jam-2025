using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float damage = 5f;
    // The time to wait before dealing damage.
    public float damageInterval = 0.5f;
    public float health = 50f;
    public Slider healthBar;


    private PlayerController player;
    private bool insidePlayer = false;
    private float timeSinceLastDamage = 0f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = target.gameObject.GetComponent<PlayerController>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        healthBar.maxValue = health;
    }

    void Update()
    {
        healthBar.value = health;
        // Check our health
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        // Move towards player
        Vector2 newPos = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(newPos);

        // Deal damage to player after x amount of time
        if (insidePlayer)
        {
            timeSinceLastDamage += Time.deltaTime;

            if (timeSinceLastDamage >= damageInterval)
            {
                Debug.Log("[EnemyController.cs] dealing damage to player");
                player.health -= damage;
                timeSinceLastDamage = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform == target)
        {
            insidePlayer = true;
            // Trigger a damage effect immediately
            timeSinceLastDamage = damageInterval;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.transform == target)
        {
            insidePlayer = false;
            timeSinceLastDamage = 0f;
        }
    }
}