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
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().health -= damage;
            Destroy(gameObject);
        }
    }
}
