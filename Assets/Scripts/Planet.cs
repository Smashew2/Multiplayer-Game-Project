using UnityEngine;
using Unity.Netcode;

public class Planet : NetworkBehaviour
{
    public int maxHealth = 15;
    [HideInInspector] public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (!IsServer)
            return;

        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0);

        // Update the health value on all clients
        UpdateHealthOnClientsClientRpc(currentHealth);
    }

    [ClientRpc]
    private void UpdateHealthOnClientsClientRpc(int health)
    {
        currentHealth = health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            // Check if the projectile collides with the shield ship
            DecreaseHealth(1); // Adjust the damage value as needed
            // Destroy the projectile
            Destroy(other.gameObject);
        }
    }

    public void DecreaseHealth(int damageAmount)
    {
        if (!IsServer)
            return;

        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0);

        // Update the health value on all clients
        UpdateHealthOnClientsClientRpc(currentHealth);
    }
}
