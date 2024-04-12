using UnityEngine;

public class ShieldShip : MonoBehaviour
{
    // Method to handle collision with other objects
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the shield ship collided with a player missile
        if (other.CompareTag("PlayerMissile"))
        {
            // Missile passed through the shield ship, do nothing
        }
    }
}
