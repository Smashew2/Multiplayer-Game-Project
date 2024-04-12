using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JoinGame : MonoBehaviour
{
    public InputField lobbyIDInput; // Reference to the input field for entering the lobby ID

    // Method called when the "Join Game" button is clicked
    public void OnJoinGameClicked()
    {
        // Get the entered lobby ID from the input field
        string enteredLobbyID = lobbyIDInput.text;

        // Check if the entered lobby ID is not empty
        if (!string.IsNullOrEmpty(enteredLobbyID))
        {
            // Pass the entered lobby ID to the character select scene and load the scene
            PlayerPrefs.SetString("EnteredLobbyID", enteredLobbyID);
            SceneManager.LoadScene("CharacterSelectScene");
        }
        else
        {
            // Display an error message indicating that the lobby ID is empty
            Debug.LogError("Please enter a lobby ID!");
            // You can display an error message to the player in the UI if needed
        }
    }
}
