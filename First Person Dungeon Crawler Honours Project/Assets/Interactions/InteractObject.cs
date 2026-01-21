using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class InteractObject : MonoBehaviour
{
    public string interactionText = "Press Space to Interact";
    public UnityEvent onInteract;
    PlayerController playerController;
    [SerializeField] GameObject player;
    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

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
        StartCoroutine("MoveFloorCorutine");
    }
    IEnumerator MoveFloorCorutine()
    {
        DataCarryScript.instance.movementDisabled = true;
        yield return new WaitForSeconds(0.01f);
        player.transform.position = new Vector3(0,1,0);
        yield return new WaitForSeconds(0.01f);
        DataCarryScript.instance.movementDisabled = false;
        SceneManager.LoadScene("Level2");
        
    }

}
