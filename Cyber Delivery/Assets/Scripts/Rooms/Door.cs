using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform previousRoom;
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraController cam;
    private UIManager uiManager;

    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            uiManager.GameOver();

            // Disable the youDied text
            if (uiManager.youDied != null)
            {
                uiManager.youDied.gameObject.SetActive(false);
            }
        }
    }
}