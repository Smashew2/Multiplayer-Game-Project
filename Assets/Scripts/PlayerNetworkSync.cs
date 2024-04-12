using UnityEngine;
using Unity.Netcode;

public class PlayerNetworkSync : NetworkBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        if (IsLocalPlayer)
        {
            // If this is the local player, send position updates to the server
            SendPositionUpdate();
        }
    }

    // Method to send position updates to the server
    private void SendPositionUpdate()
    {
        // Get the current position of the player
        Vector3 currentPosition = transform.position;

        // Call the method to update the position on the server
        UpdatePositionServerRpc(currentPosition);
    }

    // Server RPC to update the position on all clients
    [ServerRpc(RequireOwnership = false)]
    private void UpdatePositionServerRpc(Vector3 position)
    {
        // Call the method to update the position on all clients
        UpdatePositionClientRpc(position);
    }

    // Client RPC to update the position on all clients
    [ClientRpc]
    private void UpdatePositionClientRpc(Vector3 position)
    {
        // Update the position of the player on all clients
        rb.position = position;
    }
}
