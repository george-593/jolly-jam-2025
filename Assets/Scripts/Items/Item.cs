using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    // Collectables play audio??

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();

            ApplyEffect(player);
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyEffect(PlayerController player);
}
