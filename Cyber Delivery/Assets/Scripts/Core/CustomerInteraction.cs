using UnityEngine;
using TMPro;

public class CustomerInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText; // Reference to the TextMesh Pro component for the dialogue text
    private bool isPlayerNearby = false;

    private void Start()
    {
        // Ensure the dialogue text is hidden at the start of the game
        dialogueText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Check for player interaction when nearby
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ShowDialogue();
        }
    }

    private void ShowDialogue()
    {
        dialogueText.gameObject.SetActive(true); // Show the TextMesh Pro dialogue text
    }

    private void HideDialogue()
    {
        dialogueText.gameObject.SetActive(false); // Hide the TextMesh Pro dialogue text
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true; // Player is near NPC
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false; // Player leaves NPC's range
            HideDialogue(); // Hide the dialogue text
        }
    }
}
