using System;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class CommandLineHandler : MonoBehaviour
{
    void Start()
    {
        string[] args = Environment.GetCommandLineArgs();

        if (Array.Exists(args, arg => arg.Equals("-mode", StringComparison.OrdinalIgnoreCase)))
        {
            if (Array.Exists(args, arg => arg.Equals("server", StringComparison.OrdinalIgnoreCase)))
            {
                StartHost();
            }
            else if (Array.Exists(args, arg => arg.Equals("client", StringComparison.OrdinalIgnoreCase)))
            {
                StartClient();
            }
        }
    }

    private void StartHost()
    {
        // Start the host using Unity.Netcode.NetworkManager
        NetworkManager.Singleton.StartHost();
    }

    private void StartClient()
    {
        // Start the client using Unity.Netcode.NetworkManager
        NetworkManager.Singleton.StartClient();
    }
}
