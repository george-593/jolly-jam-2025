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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = target.gameObject.GetComponent<PlayerController>();
    }

    void Update()
    {
        // Move towards player
        Vector2 myPos = transform.position;
        Vector2 targetPos = target.position;
        transform.position = Vector2.MoveTowards(myPos, targetPos, speed * Time.deltaTime);

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