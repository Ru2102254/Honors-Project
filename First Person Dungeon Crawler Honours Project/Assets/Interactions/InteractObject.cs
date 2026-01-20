using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InteractObject : MonoBehaviour
{
    public string interactionText = "Press Space to Interact";
    public UnityEvent onInteract;

    public string GetInteractionText()
    {
        return interactionText;
    }

    public void Interact()
    {
        onInteract.Invoke();
    }

    public void MoveFloor()
    {
        SceneManager.LoadScene("Level2");
    }

}
