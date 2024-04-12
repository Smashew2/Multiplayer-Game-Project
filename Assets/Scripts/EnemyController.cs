using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1f;  // Speed of enemy movement
    public float boundaryX = 10f;  // Boundary for horizontal movement
    private int direction = 1;  // Movement direction: 1 for right, -1 for left

    private bool isMovementEnabled = true;

    void Update()
    {
        if (isMovementEnabled)
        {
            MoveEnemies();
        }
    }

    void MoveEnemies()
    {
        // Move enemies horizontally
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        // Check if enemies reach screen boundaries
        if (transform.position.x >= boundaryX && direction == 1)
        {
            // Reverse movement direction
            direction = -1;
        }
        else if (transform.position.x <= -boundaryX && direction == -1)
        {
            // Reverse movement direction
            direction = 1;
        }

        // Clamp enemy position to stay within specified boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -boundaryX, boundaryX);
        transform.position = clampedPosition;
    }

    public void StopMovement()
    {
        isMovementEnabled = false;
        // Additional logic to stop movement if needed
    }

    public void ResumeMovement()
    {
        isMovementEnabled = true;
        // Additional logic to resume movement if needed
    }
}
