using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public float minShootDelay = 7f;
    public float maxShootDelay = 11f;
    public float bulletSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private float nextShootTime;

    private void Start()
    {
        nextShootTime = Time.time + Random.Range(minShootDelay, maxShootDelay);
    }

    private void Update()
    {
        if (Time.time >= nextShootTime)
        {
            ShootAtPlayer();
            nextShootTime = Time.time + Random.Range(minShootDelay, maxShootDelay);
        }
    }

    private void ShootAtPlayer()
    {
        if(player != null && player.CompareTag("Player"))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            Vector3 direction = (player.position - bullet.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
        }
    }
}
