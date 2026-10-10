using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Charlie Dobson
/// 
/// Player controller script
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Movement 
    Rigidbody playerRB;
    private Vector2 movementInput;
    [SerializeField] float movementSpeed = 5;
    public Camera Cam;


    public IInteractable interactable;
    private void Start()
    {
        if(playerRB == null)
        {
            playerRB = GetComponent<Rigidbody>();
        }
        if(Cam == null)
        {
            Cam = FindAnyObjectByType<Camera>();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (possessedObject != null)
        {
            possessedObject.Move(context);
        }
        else
        {
            movementInput = context.ReadValue<Vector2>();
        }
        

    }

    private void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        Vector3 move = new Vector3(movementInput.x, 0 , movementInput.y) * movementSpeed * Time.deltaTime;
        move = Quaternion.Euler(0, Cam.transform.eulerAngles.y, 0) * move;
        playerRB.MovePosition(playerRB.position + move);
    }

    #region Trigger Enter/Exit
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IInteractable foundInteractable))
        {
            interactable = foundInteractable;
        }
        if (other.TryGetComponent(out Possessable foundPossessable))
        {
            currentPossessable = foundPossessable;
            Debug.Log(currentPossessable);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable foundInteractable))
        {
            interactable = null;
        }
        if (other.TryGetComponent(out Possessable foundPossessable))
        {
            currentPossessable = null;
        }
    }
    #endregion

    // Interact
    public void OnInteract(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            if (possessedObject != null)
            {
                //triggers action of possessed object
                possessedObject.Action();
            }
            else if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
    
    //possession mechanics
    public Possessable possessedObject;
    

    private Possessable currentPossessable;
    
    

    public void Possess(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (possessedObject != null)
            {
                //if already possessing object stops possessing it
                Debug.Log("Stopped possessing" + possessedObject);
                possessedObject = null;
            }
            else if (currentPossessable != null)
            {
                //if possessable is in range then possess object
                Debug.Log("possessed " + currentPossessable);
                possessedObject = currentPossessable;
            }
        }
    }
    


    
}
