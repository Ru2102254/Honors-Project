using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{

    public Camera playerCamera;
    public float interactionDistance = 3f;
    public GameObject interactionText;
    private InteractObject currentInteractable; 


    // Update is called once per frame
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InteractObject interactableObject = hit.collider.GetComponent<InteractObject>();
            if (interactableObject != null && interactableObject != currentInteractable)
            {
                currentInteractable = interactableObject;
                interactionText.SetActive(true);
                TextMeshProUGUI textComponent = interactionText.GetComponent<TextMeshProUGUI>();
                if (textComponent != null) {
                    textComponent.text = currentInteractable.GetInteractionText();
                
                }
            }
        }
        else { 
            currentInteractable = null; 
            interactionText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentInteractable?.Interact();
        }
    }
}
