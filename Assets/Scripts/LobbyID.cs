using UnityEngine;
using UnityEngine.UI;

public class LobbyID : MonoBehaviour
{
    public Text lobbyIDText; // Reference to the Text component displaying the lobby ID

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the lobby ID stored in PlayerPrefs
        string lobbyID = PlayerPrefs.GetString("LobbyID");

        // Update the Text component to display the lobby ID
        lobbyIDText.text = "Lobby ID: " + lobbyID;
    }
}
