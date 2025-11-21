using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    public float speed = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void Update()
    {
        // Move towards closest enemy
        Vector2 myPos = transform.position;
        Vector2 targetPos = target.position;
        transform.position = Vector2.MoveTowards(myPos, targetPos, speed * Time.deltaTime);
    }
}
