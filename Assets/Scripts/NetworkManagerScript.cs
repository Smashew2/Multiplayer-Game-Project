using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using System; // Add this line to import the System namespace

public class NetworkManagerScript : MonoBehaviour
{
    // Singleton instance of the NetworkManagerScript
    public static NetworkManagerScript Instance { get; private set; }

    // Reference to the status text
    public Text statusText;

    private void Awake()
    {
        // Ensure there's only one instance of the NetworkManagerScript
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Optionally, prevent the GameObject from being destroyed on scene changes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Subscribe to network events
        NetworkManager.Singleton.OnClientConnectedCallback += ClientConnected;

        // Check if started as host or client
        string[] args = System.Environment.GetCommandLineArgs();
        if (Array.Exists(args, arg => arg == "-mode"))
        {
            if (Array.Exists(args, arg => arg == "host"))
            {
                StartHosting();
            }
            else if (Array.Exists(args, arg => arg == "client"))
            {
                StartClient();
            }
        }
        else // If not specified, default to host
        {
            StartHosting();
        }
    }

    private void StartHosting()
    {
        // Start hosting the game
        NetworkManager.Singleton.StartHost();

        // Update status
        UpdateStatus("Hosting...");
        Debug.Log("Game is Hosted");
    }

    private void StartClient()
    {
        // Start as client and connect to host
        NetworkManager.Singleton.StartClient();

        // Update status
        UpdateStatus("Connecting as Client...");
        Debug.Log("Connecting as Client...");
    }

    private void ClientConnected(ulong clientId)
    {
        UpdateStatus("Connected as Client");
    }

    private void UpdateStatus(string text)
    {
        if (statusText != null)
        {
            statusText.text = text;
        }
    }
}
