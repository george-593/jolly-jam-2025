using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public float speed = 3f;
    public float damage = 5f;
    // The time to wait before dealing damage.
    public float damageInterval = 0.5f;

    private PlayerController player;
    private bool insidePlayer = false;
    private float timeSinceLastDamage = 0f;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = target.gameObject.GetComponent<PlayerController>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move towards closest enemy
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