using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    // Serialized fields for customization
    [SerializeField] private bool moveOnXAxis = true;  // Toggle for X-axis or Y-axis movement
    [SerializeField] private float moveDistance = 3f;  // Distance the platform will move
    [SerializeField] private float moveSpeed = 2f;     // Speed of the platform's movement

    private Vector3 startingPosition;

    void Start()
    {
        // Save the platform's starting position
        startingPosition = transform.position;
    }

    void Update()
    {
        // Calculate the movement offset based on time
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance);

        if (moveOnXAxis)
        {
            // Move platform on the X-axis
            transform.position = new Vector3(startingPosition.x + offset, startingPosition.y, startingPosition.z);
        }
        else
        {
            // Move platform on the Y-axis
            transform.position = new Vector3(startingPosition.x, startingPosition.y + offset, startingPosition.z);
        }
    }
}
