using UnityEngine;
using UnityEngine.Networking;

public class GameplayManager : MonoBehaviour
{
    public Transform spawnPoint1; // Spawn point for player 1
    public Transform spawnPoint2; // Spawn point for player 2

    // Prefabs for player 1 and player 2
    [SerializeField] private GameObject player1Prefab;
    [SerializeField] private GameObject player2Prefab;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the prefabs are assigned
        if (player1Prefab != null && player2Prefab != null)
        {
            // Instantiate the player prefabs at their respective spawn points
            Instantiate(player1Prefab, spawnPoint1.position, spawnPoint1.rotation);
            Instantiate(player2Prefab, spawnPoint2.position, spawnPoint2.rotation);
        }
        else
        {
            Debug.LogError("Player prefabs are not assigned!");
        }
    }
}
