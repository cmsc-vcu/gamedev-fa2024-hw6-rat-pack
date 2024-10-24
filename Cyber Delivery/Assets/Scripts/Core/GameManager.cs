using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int packagesDelivered = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Function to reset the package count
    public void ResetPackageCount()
    {
        packagesDelivered = 0; // Reset the delivered packages count
    }

    // Function to increment the package count when a package is delivered
    public void PackageDelivered()
    {
        packagesDelivered++;
    }

    public int GetDeliveredPackageCount()
    {
        return packagesDelivered;
    }
}
