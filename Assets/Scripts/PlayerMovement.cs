using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;  // Movement speed of the player ship
    public float boundaryX = 5f;  // Boundary for horizontal movement

    private bool isMovementEnabled = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Freeze rotation and lock Y-axis movement
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
    }

    void Update()
    {
        if (isMovementEnabled)
        {
            // Get player input for horizontal movement
            float horizontalInput = Input.GetAxis("Horizontal");

            // Move the player ship horizontally
            Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);

            // Keep the player ship within the boundaries
            float clampedX = Mathf.Clamp(transform.position.x, -boundaryX, boundaryX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

    public void StopMovement()
    {
        isMovementEnabled = false;
    }

    public void ResumeMovement()
    {
        isMovementEnabled = true;
    }
}
