using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string hostOrJoinSceneName = "CharacterSelectScene"; // Name of the host or join scene
    public GameObject gameplayElementsPrefab; // Reference to the gameplay elements prefab

    private GameObject gameplayElementsInstance; // Reference to the instantiated gameplay elements

    public void StartGame()
    {
        // Load the host or join scene instead of the character select scene
        SceneManager.LoadScene("CharacterSelectScene");
    }

    public void ShowInfo()
    {
        // Load the Info scene
        SceneManager.LoadScene("Info");
    }

    public void ExitGame()
    {
        // Quit the application
        Application.Quit();
    }

    void OnEnable()
    {
        // Ensure the gameplay elements are not instantiated multiple times
        if (gameplayElementsInstance == null && SceneManager.GetActiveScene().name == hostOrJoinSceneName)
        {
            // Instantiate the gameplay elements prefab
            gameplayElementsInstance = Instantiate(gameplayElementsPrefab);
        }
    }

    void OnDisable()
    {
        // Destroy the instantiated gameplay elements when the MainMenu is disabled
        if (gameplayElementsInstance != null)
        {
            Destroy(gameplayElementsInstance);
        }
    }
}
