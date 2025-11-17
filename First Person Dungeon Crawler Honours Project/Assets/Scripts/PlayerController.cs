using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    public bool smoothMovement = true;
    public float movementSpeed = 15f;
    public float movementRotationSpeed = 600f;
    PlayerInput playerInput;
    InputAction moveAction;

    Vector3 toGridPos;
    Vector3 backGridPos;
    Vector3 gridRotation;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        toGridPos = Vector3Int.RoundToInt(transform.position);
    }

    void Update()
    {
        
        MovePlayer();
    }

    void MovePlayer()
    {
        
       
        Vector2 moveDirection = moveAction.ReadValue<Vector2>();
        //freemovement
        //transform.position += new Vector3(direction.x, 0, direction.y) * Time.deltaTime;


        //Snapping Movement
        if (true)
        {
            backGridPos = toGridPos;
            Vector3 targetPosition = toGridPos;
            //Rotation
            if (gridRotation.y > 270 && gridRotation.y < 361) gridRotation.y = 0f;
            if (gridRotation.y < 0f) gridRotation.y = 270f;
            //Movement
            if (!smoothMovement)
            {
                transform.position = targetPosition;
                transform.rotation = Quaternion.Euler(gridRotation);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(gridRotation), Time.deltaTime * movementRotationSpeed);
            }

        }
        else
        {
            toGridPos = backGridPos;
        }

    }


    ////Controlls
    public void RotateLeft() { if (stopping) gridRotation -= Vector3.up * 90f; }
    public void RotateRight() { if (stopping) gridRotation += Vector3.right * 90f; }
    public void MoveForward() { if (stopping) toGridPos += transform.forward; }
    public void MoveBack() { if (stopping) toGridPos -= transform.forward; }
    public void MoveRight() { if (stopping) toGridPos += transform.right; }
    public void MoveLeft() { if (stopping) toGridPos -= transform.right; }

    float leeway = 0.01f;
    bool stopping
    {
        get
        {
            if ((Vector3.Distance(transform.position, toGridPos) < leeway) && (Vector3.Distance(transform.eulerAngles, gridRotation) < leeway))
                return true;
            else
                return false;

        }
    }
}
