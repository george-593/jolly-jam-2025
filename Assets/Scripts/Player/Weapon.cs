using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] bullets;
    public Transform firepoint;
    public float fireForce;

    public void Fire()
    {
        GameObject bullet = Instantiate(GetRandomBullet(), firepoint.position, firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * fireForce, ForceMode2D.Impulse);
    }

    private GameObject GetRandomBullet()
    {
        return bullets[Random.Range(0, bullets.Length)];
    }
}
