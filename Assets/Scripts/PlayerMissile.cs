using Unity.Netcode;
using UnityEngine;

public class PlayerMissile : NetworkBehaviour
{
    public int damage = 1; // Damage inflicted by the projectile
    public float speed = 10f; // Speed of the projectile

    void Update()
    {
        // Move the projectile to the right
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check for collision with an enemy
        if (other.CompareTag("Enemy"))
        {
            // Get the EnemyHealth component of the collided enemy
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            // If the EnemyHealth component is found, inflict damage
            if (enemyHealth != null)
            {
                // Inflict damage on the enemy
                enemyHealth.TakeDamage(damage);
            }

            // Destroy the projectile upon hitting the enemy
            Destroy(gameObject);
        }
    }

    [ServerRpc]
    public void DestroyProjectileServerRpc()
    {
        // Destroy the projectile on all clients
        NetworkObject.Destroy(gameObject);
    }
}
