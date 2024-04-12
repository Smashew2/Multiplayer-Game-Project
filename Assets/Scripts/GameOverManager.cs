using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject youLoseScreen;
    public GameObject youSurvivedScreen;

    void Start()
    {
        Debug.Log("GameOverManager Start() called");

        // Ensure both game over screens start as inactive
        if (youLoseScreen != null)
            youLoseScreen.SetActive(false);
        if (youSurvivedScreen != null)
            youSurvivedScreen.SetActive(false);

        // Subscribe to game over events from GameManager
        Debug.Log("Subscribing to game over events");
        GameManager.OnLoseGame += ShowYouLoseScreen;
        GameManager.OnSurvivalGame += ShowYouSurvivedScreen;
    }

    void OnDestroy()
    {
        // Unsubscribe from game over events to avoid memory leaks
        GameManager.OnLoseGame -= ShowYouLoseScreen;
        GameManager.OnSurvivalGame -= ShowYouSurvivedScreen;
    }

    void ShowYouLoseScreen()
    {
        Debug.Log("ShowYouLoseScreen() called");

        if (youLoseScreen != null)
        {
            // Ensure both game over screens are inactive before activating the appropriate one
            if (youSurvivedScreen != null && youSurvivedScreen.activeSelf)
                youSurvivedScreen.SetActive(false);

            youLoseScreen.SetActive(true);
        }

        DisablePlayerAndEnemies();
    }

    void ShowYouSurvivedScreen()
    {
        Debug.Log("ShowYouSurvivedScreen() called");

        if (youSurvivedScreen != null)
        {
            // Ensure both game over screens are inactive before activating the appropriate one
            if (youLoseScreen != null && youLoseScreen.activeSelf)
                youLoseScreen.SetActive(false);

            youSurvivedScreen.SetActive(true);
        }

        DisablePlayerAndEnemies();
    }

    void DisablePlayerAndEnemies()
    {
        Debug.Log("Disabling Player and Enemies");

        // Disable player control and firing
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement != null)
            playerMovement.StopMovement();

        // Stop enemy spawning, movement, and firing
        EnemySpawner[] enemySpawners = FindObjectsOfType<EnemySpawner>();
        foreach (EnemySpawner spawner in enemySpawners)
        {
            spawner.StopSpawning();
        }
        EnemyController[] enemyControllers = FindObjectsOfType<EnemyController>();
        foreach (EnemyController controller in enemyControllers)
        {
            controller.StopMovement();
        }
        EnemyFire[] enemyFires = FindObjectsOfType<EnemyFire>();
        foreach (EnemyFire fire in enemyFires)
        {
            fire.StopFiring();
        }
    }
}
