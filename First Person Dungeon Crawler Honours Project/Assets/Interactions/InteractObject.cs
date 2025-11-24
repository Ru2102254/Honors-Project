using UnityEngine;
using UnityEngine.Events;

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

}
