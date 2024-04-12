using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject youLoseScreen;
    public GameObject youSurvivedScreen;
    public Planet planet; // Reference to the Planet script
    public static UnityAction OnLoseGame;
    public static UnityAction OnSurvivalGame;

    private bool gameOver = false; // Flag to track if game over condition is reached

    void Start()
    {
        // Ensure both game over screens start as inactive
        if (youLoseScreen != null)
            youLoseScreen.SetActive(false);
        if (youSurvivedScreen != null)
            youSurvivedScreen.SetActive(false);

        // Subscribe to game over events
        OnLoseGame += () => GameOver(youLoseScreen);
        OnSurvivalGame += () => GameOver(youSurvivedScreen);
    }

    void Update()
    {
        Debug.Log("Time since level load: " + Time.timeSinceLevelLoad);
        Debug.Log("Planet current health: " + (planet != null ? planet.currentHealth.ToString() : "Planet reference not assigned"));
        // Check if the game over condition hasn't been reached yet
        if (!gameOver)
        {
            // Check if the planet's health has reached zero
            if (planet != null && planet.currentHealth <= 0)
            {
                // Trigger game over with "You Lose" screen if the planet's health is zero or below
                OnLoseGame?.Invoke();
            }
            else if (Time.timeSinceLevelLoad >= 45f) // Check if 45 seconds have passed
            {
                // Trigger game over with "You Survived" screen if the planet's health is still above zero after 45 seconds
                OnSurvivalGame?.Invoke();
            }
        }
    }

    // Method to handle game over logic
    void GameOver(GameObject gameOverScreen)
    {
        // Activate the appropriate game over screen when the game ends
        if (gameOverScreen != null)
        {
            // Deactivate both game over screens before activating the appropriate one
            if (youLoseScreen != null && youLoseScreen.activeSelf)
                youLoseScreen.SetActive(false);

            if (youSurvivedScreen != null && youSurvivedScreen.activeSelf)
                youSurvivedScreen.SetActive(false);

            // Activate the specified game over screen
            gameOverScreen.SetActive(true);
        }

        // Indicate that the game is over to prevent further updates
        gameOver = true;
    }
}
