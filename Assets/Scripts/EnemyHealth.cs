using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 1; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Decrease current health by the damage amount

        // Check if the enemy has run out of health
        if (currentHealth <= 0)
        {
            // Check if the enemy has a specific name before destroying it
            if (gameObject.name == "Enemy_3_A_Small(Clone)")
            {
                Destroy(gameObject); // Destroy the enemy object
            }
            else
            {
                // Do nothing if the enemy doesn't have the specific name
                Debug.Log("Enemy " + gameObject.name + " does not match the specified name.");
            }
        }
    }
}
