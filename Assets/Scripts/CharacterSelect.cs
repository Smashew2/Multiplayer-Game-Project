using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class CharacterSelect : NetworkBehaviour
{
    public Button startGameButton; // Reference to the button that starts the game

    private string player1Selection = null;
    private string player2Selection = null;

    public void SelectCharacterPrefab1()
    {
        player1Selection = "Defender";
        if (IsServer)
        {
            // Call the server method to update the selection
            UpdatePlayerSelectionServerRpc(player1Selection);
        }
        else
        {
            // Call the server method through client RPC to update the selection
            UpdatePlayerSelectionClientRpc(player1Selection);
        }
    }

    public void SelectCharacterPrefab2()
    {
        player2Selection = "Attacker";
        if (IsServer)
        {
            // Call the server method to update the selection
            UpdatePlayerSelectionServerRpc(player2Selection);
        }
        else
        {
            // Call the server method through client RPC to update the selection
            UpdatePlayerSelectionClientRpc(player2Selection);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    private void UpdatePlayerSelectionServerRpc(string selection)
    {
        if (player1Selection == null)
        {
            player1Selection = selection;
        }
        else if (player2Selection == null)
        {
            player2Selection = selection;
        }

        // Check if both players have made their selections
        if (player1Selection != null && player2Selection != null)
        {
            // Activate the start game button
            startGameButton.interactable = true;

            // Notify all clients to enable the start game button
            EnableStartGameButtonClientRpc();
        }
    }

    [ClientRpc]
    private void UpdatePlayerSelectionClientRpc(string selection)
    {
        // Call the local method to update the selection
        UpdatePlayerSelection(selection);
    }

    // Local method to update the selection
    private void UpdatePlayerSelection(string selection)
    {
        // Update the selection based on the client's role
        if (IsLocalPlayer)
        {
            if (player1Selection == null)
            {
                player1Selection = selection;
            }
            else if (player2Selection == null)
            {
                player2Selection = selection;
            }

            // Check if both players have made their selections
            if (player1Selection != null && player2Selection != null)
            {
                // Activate the start game button
                startGameButton.interactable = true;
            }
        }
    }

    [ClientRpc]
    private void EnableStartGameButtonClientRpc()
    {
        // Activate the start game button on all clients
        startGameButton.interactable = true;
    }

    // Method to start the game (assigned to the onClick event of the start game button)
    public void StartGame()
    {
        // Transition to the gameplay scene
        SceneManager.LoadScene("SampleScene");
    }
}
