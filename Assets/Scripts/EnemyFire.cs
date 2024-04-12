using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform firePoint;         // Point from which the projectile is fired
    public float fireInterval = 2f;     // Interval between shots in seconds

    private float lastShootTime;        // Time when the enemy last shot
    private bool isFiringEnabled = true;

    void Start()
    {
        // Initialize last shoot time
        lastShootTime = Time.time;
    }

    void Update()
    {
        if (isFiringEnabled && Time.time - lastShootTime >= fireInterval)
        {
            // Shoot a projectile
            ShootProjectile();

            // Update last shoot time
            lastShootTime = Time.time;
        }
    }

    void ShootProjectile()
    {
        // Instantiate a projectile at the fire point
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }

    public void StopFiring()
    {
        isFiringEnabled = false;
        // Additional logic to stop firing if needed
    }

    public void ResumeFiring()
    {
        isFiringEnabled = true;
        // Additional logic to resume firing if needed
    }
}
