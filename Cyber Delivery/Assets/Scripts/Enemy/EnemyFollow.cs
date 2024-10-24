using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player
    [SerializeField] private float speed = 3f; // Speed of the enemy
    [SerializeField] private Vector2 roomBoundsMin; // Minimum X and Y coordinates of the room
    [SerializeField] private Vector2 roomBoundsMax; // Maximum X and Y coordinates of the room

    private Vector3 originalScale; // To store the original scale of the enemy

    private void Start()
    {
        // Store the original scale at the start
        originalScale = transform.localScale;
    }

    private void Update()
    {
        // Check if the player is inside the room bounds
        if (IsPlayerInRoom())
        {
            // Calculate direction to the player
            Vector3 direction = player.position - transform.position;
            direction.z = 0; // Ensure the movement is confined to 2D

            // Normalize the direction and move the enemy
            Vector3 newPosition = transform.position + direction.normalized * speed * Time.deltaTime;

            // Restrict the enemy's position within the room bounds
            newPosition.x = Mathf.Clamp(newPosition.x, roomBoundsMin.x, roomBoundsMax.x);
            newPosition.y = Mathf.Clamp(newPosition.y, roomBoundsMin.y, roomBoundsMax.y);

            // Apply the new position
            transform.position = newPosition;

            // Flip the enemy based on the direction
            if (direction.x > 0) // Moving right
            {
                transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
            else if (direction.x < 0) // Moving left
            {
                transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
            }
        }
    }

    // Function to check if the player is within the room bounds
    private bool IsPlayerInRoom()
    {
        Vector3 playerPos = player.position;

        // Debug logs to check positions
        Debug.Log($"Player Position: {playerPos}");
        Debug.Log($"Room Bounds: Min({roomBoundsMin.x}, {roomBoundsMin.y}), Max({roomBoundsMax.x}, {roomBoundsMax.y})");

        return playerPos.x >= roomBoundsMin.x && playerPos.x <= roomBoundsMax.x &&
               playerPos.y >= roomBoundsMin.y && playerPos.y <= roomBoundsMax.y;
    }
}
