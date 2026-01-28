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
    public void MoveFloor(int floorNum)
    {
        StartCoroutine("MoveToZeroCorutine", floorNum);

    }
    IEnumerator MoveToZeroCorutine(int floorNum)
    {
        DataCarryScript.instance.movementDisabled = true;
        yield return new WaitForSeconds(0.1f);
        DataCarryScript.instance.PlayerPositionData = new Vector3(0,1,0);
        player.transform.rotation = new Quaternion(0,0,0,0);
        yield return new WaitForSeconds(0.1f);
        DataCarryScript.instance.movementDisabled = false;

        switch (floorNum)
        {
            case 0:
                DataCarryScript.instance.locationData = "Level 2";
                SceneManager.LoadScene("Level2");
                break;
            case 1:
                DataCarryScript.instance.locationData = "Level 3";
                SceneManager.LoadScene("Level3");
                break;
            case 2:
                DataCarryScript.instance.locationData = "Level 4";
                SceneManager.LoadScene("Level4");
                break;
            case 3:
                DataCarryScript.instance.locationData = "Level 5";
                SceneManager.LoadScene("Level5_FinalLevel");
                break;
        }
    }

}
