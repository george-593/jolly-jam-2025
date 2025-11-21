using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public float speed = 3f;
    public float damage = 5f;

    private PlayerController player;
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
        Vector2 myPos = transform.position;
        Vector2 targetPos = target.position;
        transform.position = Vector2.MoveTowards(myPos, targetPos, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform == target)
        {
            Debug.Log("[EnemyController.cs] collided with player");
            // Deduct health from player
            player.health -= damage;
        }
    }
}
