using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    public bool smoothMovement = true;
    public bool freeMovement = true;
    public float movementSpeed = 1f;
    public float movementRotationSpeed = 600f;

    public Transform orientation;

    PlayerInput playerInput;
    InputAction moveAction;
    InputAction rotateAction;

    Vector2 moveDirection;
    Vector2 lookDirection;

    Vector3 toGridPos;
    Vector3 backGridPos;
    Vector3 gridRotation;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
        rotateAction = playerInput.actions.FindAction("Rotate");
    }

    void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
        lookDirection = rotateAction.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {

        //freemovement
        transform.position += new Vector3(moveDirection.x, 0, moveDirection.y) * movementSpeed * Time.deltaTime;
        

        //Snapping Movement
        if (!freeMovement)
        {
            backGridPos = toGridPos;
            //Rotation
            if (gridRotation.y > 270 && gridRotation.y < 361) gridRotation.y = 0f;
            if (gridRotation.y < 0f) gridRotation.y = 270f;
            //Movement
            if (!smoothMovement)
            {
                //transform.position = targetPosition;
                transform.position = new Vector3(moveDirection.x, 0, moveDirection.y) * movementSpeed;
                transform.rotation = Quaternion.Euler(gridRotation);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, moveDirection, Time.deltaTime * movementSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(gridRotation), Time.deltaTime * movementRotationSpeed);
            }

        }
        else
        {
            toGridPos = backGridPos;
        }

    }

    void RotatePlayer()
    {
        if (lookDirection.y != 0)
        {
            float roationAmount = lookDirection.x * movementRotationSpeed * Time.deltaTime;
            Quaternion deltaRotation = Quaternion.Euler(0, roationAmount, 0);
            transform.rotation *= deltaRotation;
            //NonFree Rotate
            //transform.rotation = Quaternion.Euler(0, roationAmount, 0);
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
