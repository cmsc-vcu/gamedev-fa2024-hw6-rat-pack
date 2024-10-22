using System.Collections.Generic;
using UnityEngine;

public class PlatformPuzzle : MonoBehaviour
{
    public GameObject[] platforms;  // Assign your platforms in the inspector
    public GameObject door;         // Assign the door object in the inspector
    public Color steppedOnColor;    // The color to change the platform to when stepped on

    private List<GameObject> correctPattern = new List<GameObject>();  // The correct sequence
    private List<GameObject> playerPattern = new List<GameObject>();   // Player's current sequence
    private bool isDoorUnlocked = false;

    void Start()
    {
        // Define the correct pattern in the Start method
        correctPattern.Add(platforms[0]);
        correctPattern.Add(platforms[2]);
        correctPattern.Add(platforms[1]);
        correctPattern.Add(platforms[3]);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player stepped on platform: " + gameObject.name);
            PlayerJumpedOnPlatform(gameObject);
        }
    }

    public void PlayerJumpedOnPlatform(GameObject platform)
    {
        if (!isDoorUnlocked)
        {
            // Change the color of the platform when stepped on
            ChangePlatformColor(platform);

            // Add the platform to the player's sequence
            playerPattern.Add(platform);

            // Check if the player has completed the sequence
            if (playerPattern.Count == correctPattern.Count)
            {
                if (IsCorrectPattern())
                {
                    UnlockDoor();
                }
                else
                {
                    // Reset the player's sequence and reset platform colors if the pattern is wrong
                    ResetPlatforms();
                    playerPattern.Clear();
                }
            }
        }
    }

    private bool IsCorrectPattern()
    {
        for (int i = 0; i < correctPattern.Count; i++)
        {
            if (playerPattern[i] != correctPattern[i])
                return false;
        }
        return true;
    }

    private void UnlockDoor()
    {
        isDoorUnlocked = true;
        // Disable the door's collider to "unlock" it
        door.GetComponent<Collider2D>().enabled = false;
        Debug.Log("Door Unlocked!");
    }

    private void ChangePlatformColor(GameObject platform)
    {
        // Change the color of the platform to indicate it has been stepped on
        platform.GetComponent<SpriteRenderer>().color = steppedOnColor;
    }

    private void ResetPlatforms()
    {
        // Reset all platform colors to their original state
        foreach (GameObject platform in platforms)
        {
            platform.GetComponent<SpriteRenderer>().color = Color.white;  // Assuming white is the default color
        }
    }
}
