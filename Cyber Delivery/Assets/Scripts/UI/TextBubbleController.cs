using UnityEngine;
using TMPro; // Only needed if using TextMeshPro

public class TextBubbleController : MonoBehaviour
{
    public GameObject textBubblePanel;  // Reference to the panel containing the bubble
    public TMP_Text bubbleText;         // Use TMP_Text if using TextMeshPro, otherwise use Text
    public string message;              // Message to display
    public Collider2D triggerZone;

    void Start()
    {
        textBubblePanel.SetActive(false);  // Initially hide the bubble
    }

    // Show the text bubble with the given message
    public void ShowTextBubble()
    {
        bubbleText.text = message;
        textBubblePanel.SetActive(true);
    }

    // Hide the text bubble
    public void HideTextBubble()
    {
        textBubblePanel.SetActive(false);
    }

    // Detect when the player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowTextBubble();
        }
    }

    // Detect when the player exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HideTextBubble();
        }
    }
}