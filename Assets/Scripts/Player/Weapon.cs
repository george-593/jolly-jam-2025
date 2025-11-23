using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject[] bullets;
    public int numOfBullets = 1;
    public Transform firepoint;
    public float fireForce;
    public float damage;
    public float spreadAngle = 200f;

    public void Fire()
    {
        for (int i = 0; i < numOfBullets; i++)
        {
            GameObject bullet;
            // Make the first bullet always fire straight
            if (i > 0)
            {
                float randomZ = Random.Range(-spreadAngle, spreadAngle);
                Quaternion randomRotation = firepoint.rotation * Quaternion.Euler(0, 0, randomZ);
                bullet = Instantiate(GetRandomBullet(), firepoint.position, randomRotation);
            }
            else
            {
                bullet = Instantiate(GetRandomBullet(), firepoint.position, firepoint.rotation);
            }
            bullet.GetComponent<Bullet>().damage = damage;
            bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * fireForce, ForceMode2D.Impulse);
        }
    }

    private GameObject GetRandomBullet()
    {
        return bullets[Random.Range(0, bullets.Length)];
    }
}
