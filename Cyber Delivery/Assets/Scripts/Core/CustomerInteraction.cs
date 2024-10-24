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
    [SerializeField] private TextMeshProUGUI[] packageCounters; // Array to hold TextMeshPro objects for package numbers 0 to 3
    private bool isPlayerNearby = false;
    private bool hasReceivedPackage = false; // Track if this customer has already received a package

    private void Start()
    {
        // Ensure the dialogue text is hidden at the start
        dialogueText.gameObject.SetActive(false);
        // Ensure the GameOver screen and its components are hidden at the start
        gameOverScreen.SetActive(false);
        // Ensure only the "0" counter is active at the start
        UpdatePackageCounters();
    }

    private void Update()
    {
        // Check for player interaction when nearby
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !hasReceivedPackage && GameManager.Instance.GetDeliveredPackageCount() < 3)
        {
            DeliverPackage();
        }
    }

    private void DeliverPackage()
    {
        if (GameManager.Instance.GetDeliveredPackageCount() < 3)
        {
            GameManager.Instance.PackageDelivered(); // Increase global package count
            hasReceivedPackage = true; // Mark this customer as having received a package

            // Show fixed delivery message and packages remaining
            string remainingText = "Packages remaining: " + (3 - GameManager.Instance.GetDeliveredPackageCount());
            dialogueText.text = "Thank you for dropping off my package. Light Speed Delivery is the best!\n" + remainingText;
            dialogueText.gameObject.SetActive(true); // Show dialogue text

            // Update the package number counters in the UI
            UpdatePackageCounters();

            if (GameManager.Instance.GetDeliveredPackageCount() == 3)
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

    private void UpdatePackageCounters()
    {
        // Loop through all package counters and enable the one corresponding to the current package number
        for (int i = 0; i < packageCounters.Length; i++)
        {
            packageCounters[i].gameObject.SetActive(i == GameManager.Instance.GetDeliveredPackageCount()); // Enable the correct counter based on delivered packages
        }
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
