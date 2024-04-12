using UnityEngine;

public class GameOverDisabler : MonoBehaviour
{
    private void Start()
    {
        // Subscribe to game over events from GameManager
        GameManager.OnLoseGame += DisablePlayerAndEnemies;
        GameManager.OnSurvivalGame += DisablePlayerAndEnemies;
    }

    private void OnDestroy()
    {
        // Unsubscribe from game over events to avoid memory leaks
        GameManager.OnLoseGame -= DisablePlayerAndEnemies;
        GameManager.OnSurvivalGame -= DisablePlayerAndEnemies;
    }

    private void DisablePlayerAndEnemies()
    {
        // Disable player control and firing
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement != null)
            playerMovement.StopMovement(); // Assuming you have a method to stop player movement

        // Stop enemy spawning, movement, and firing
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in enemySpawners)
        {
            spawner.StopSpawning(); // Assuming you have a method to stop enemy spawning
        }

        EnemyController[] enemyControllers = FindObjectsOfType<EnemyController>();
        foreach (EnemyController controller in enemyControllers)
        {
            controller.StopMovement(); // Assuming you have a method to stop enemy movement
        }

        EnemyFire[] enemyFires = FindObjectsOfType<EnemyFire>();
        foreach (EnemyFire fire in enemyFires)
        {
            fire.StopFiring(); // Assuming you have a method to stop enemy firing
        }
    }
}
