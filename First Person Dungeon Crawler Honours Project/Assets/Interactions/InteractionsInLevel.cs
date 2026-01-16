using UnityEngine;

public class InteractionsInLevel : MonoBehaviour
{

    //Used to handle if player has interacted with objects in a level when returning May not be used if I choose to have players not return

    public static InteractionsInLevel instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Check if an instance already exists
        if (instance != null && instance != this)
        {
            // If a duplicate exists, destroy the new one
            Destroy(gameObject);
            return;
        }

        // If no instance exists, set this as the instance
        instance = this;

        // Mark the GameObject to not be destroyed when a new scene loads
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
