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
        // Initialize the nextShootTime with a random delay within the defined range.
        nextShootTime = Time.time + Random.Range(minShootDelay, maxShootDelay);
    }

    private void Update()
    {
        if (Time.time >= nextShootTime)
        {
            ShootAtPlayer();
            // Reset the nextShootTime with a new random delay.
            nextShootTime = Time.time + Random.Range(minShootDelay, maxShootDelay);
        }
    }

    private void ShootAtPlayer()
    {
        // Check if the player is in range and has the "Player" tag.
        if (player != null && player.CompareTag("Player"))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            // Calculate the direction towards the player.
            Vector3 direction = (player.position - bullet.transform.position).normalized;
            // Set the bullet's velocity to move towards the player.
            bullet.GetComponent<Rigidbody>().velocity = direction * bulletSpeed; // Adjust bulletSpeed as needed.
        }
    }
}
