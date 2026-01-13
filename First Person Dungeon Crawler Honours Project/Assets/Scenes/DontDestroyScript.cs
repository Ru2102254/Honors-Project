using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    // Stores the static reference to the single instance
    public static DontDestroyScript Instance { get; private set; }

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            // If a duplicate exists, destroy the new one
            Destroy(gameObject);
            return;
        }

        // If no instance exists, set this as the instance
        Instance = this;

        // Mark the GameObject to not be destroyed when a new scene loads
        DontDestroyOnLoad(gameObject);
    }
}
