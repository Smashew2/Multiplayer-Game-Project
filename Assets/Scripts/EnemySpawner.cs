using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Reference to the enemy prefab
    public float spawnInterval = 2f;  // Interval between enemy spawns
    public float spawnRadius = 5f;  // Radius within which enemies can spawn

    private bool isSpawningEnabled = true;

    void Start()
    {
        // Start spawning enemies at regular intervals
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (isSpawningEnabled)
        {
            // Check if the enemy prefab is assigned
            if (enemyPrefab == null)
            {
                Debug.LogError("Enemy prefab is not assigned in the EnemySpawner!");
                return;
            }

            // Generate a random position within the specified spawn radius
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            // Spawn an enemy at the random position
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }

    public void StopSpawning()
    {
        isSpawningEnabled = false;
        // Additional logic to stop spawning if needed
    }

    public void ResumeSpawning()
    {
        isSpawningEnabled = true;
        // Additional logic to resume spawning if needed
    }
}
