using UnityEngine;
using TMPro;

public class CustomerInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText; // Reference to the TextMesh Pro component for dialogue text
    [SerializeField] private GameObject gameOverScreen; // Reference to the GameOver screen GameObject
    [SerializeField] private GameObject menu; // Reference to the menu GameObject inside GameOver screen
    [SerializeField] private GameObject restartButton; // Reference to the restart button
    [SerializeField] private GameObject quitButton; // Reference to the quit button
    [SerializeField] private GameObject youWin; // Reference to the "You Win" text
    private bool isPlayerNearby = false;
    private int packagesRemaining = 3; // Total number of packages to be delivered

    private void Start()
    {
        // Ensure the dialogue text is hidden at the start
        dialogueText.gameObject.SetActive(false);
        // Ensure the GameOver screen and its components are hidden at the start
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        // Check for player interaction when nearby
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            DeliverPackage();
        }
    }

    private void DeliverPackage()
    {
        if (packagesRemaining > 0)
        {
            packagesRemaining--; // Decrease package count

            // Show fixed delivery message and packages remaining
            string remainingText = "Packages remaining: " + packagesRemaining;
            dialogueText.text = "Thank you for dropping off my package. Light Speed Delivery is the best!\n" + remainingText;
            dialogueText.gameObject.SetActive(true); // Show dialogue text

            if (packagesRemaining == 0)
            {
                ShowWinScreen(); // All packages delivered, show win screen
            }
        }
    }

    private void ShowWinScreen()
    {
        // Hide dialogue text if visible
        dialogueText.gameObject.SetActive(false);

        // Activate GameOver screen and its components
        gameOverScreen.SetActive(true);
        menu.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        youWin.SetActive(true); // Show "You Win" text
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
            dialogueText.gameObject.SetActive(false); // Hide dialogue when player leaves
        }
    }
}
