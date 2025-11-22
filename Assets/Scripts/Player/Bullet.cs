using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    // Make damage get/set to hide in editor.
    public float damage { get; set; }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().health -= damage;
            Destroy(gameObject);
        }
    }
}
