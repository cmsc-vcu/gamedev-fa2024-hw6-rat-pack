using UnityEngine;
using TMPro;

public class GameIntroduction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText; // Reference to TextMesh Pro for displaying text
    [SerializeField] private GameObject tutorialPanel; // Panel to show the tutorial text
    private int currentStep = 0; // Track current step of the tutorial

    // Introduction text
    private string[] introductionTexts = new string[]
    {
        "Hello Courier Zander! Your route today is in Sector Z. You have three packages to deliver in this Sector.",
        "Be careful, that place is heavily guarded by our business rival Nebula Corp Courier Robots.",
        "Use caution, and if force is necessary, you have your corporate issue hand blaster at the ready.",
        "Good luck Courier!"
    };

    // Controls text
    private string controlsText = "Controls:\nMove forward = 'D' or '→'\nMove backwards = 'A' or '←'\nJump = Spacebar\nAttack = Right Click\nPause Menu = ESC\nInteract with NPC = 'E'";

    private void Start()
    {
        // Automatically start the tutorial at the beginning of the game
        StartTutorial();
    }

    private void Update()
    {
        // Progress through the tutorial when the player presses space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceTutorial();
        }
    }

    // Automatically called in Start to trigger the tutorial
    private void StartTutorial()
    {
        tutorialPanel.SetActive(true); // Show the tutorial panel
        Time.timeScale = 0; // Pause the game
        DisplayText(); // Display the first piece of text
    }

    private void DisplayText()
    {
        if (currentStep < introductionTexts.Length)
        {
            dialogueText.text = introductionTexts[currentStep]; // Show current introduction text
        }
        else
        {
            dialogueText.text = controlsText; // Show controls after the introduction
        }
    }

    private void AdvanceTutorial()
    {
        if (currentStep < introductionTexts.Length)
        {
            currentStep++; // Go to the next step of introduction
            DisplayText();
        }
        else
        {
            EndTutorial(); // End the tutorial once the controls have been shown
        }
    }

    private void EndTutorial()
    {
        // Hide the tutorial panel and reset text visibility
        dialogueText.gameObject.SetActive(false); // Hide the dialogue text
        tutorialPanel.SetActive(false); // Hide the entire tutorial panel
        Time.timeScale = 1; // Resume the game
    }
}
