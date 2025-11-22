using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            // Damage enemy
            Destroy(gameObject);
        }
    }
}
