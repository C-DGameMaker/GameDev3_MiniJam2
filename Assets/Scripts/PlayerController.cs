using System;
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

    // Possession
    public bool canPossess;
    public IInteractable interactable;
    private void Start()
    {
        if(playerRB == null)
        {
            playerRB = GetComponent<Rigidbody>();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        Vector3 move = new Vector3(movementInput.x, 0 , movementInput.y) * movementSpeed * Time.deltaTime;
        playerRB.MovePosition(playerRB.position + move);
    }

    #region Trigger Enter/Exit
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IInteractable foundInteractable))
        {
            interactable = foundInteractable;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable foundInteractable))
        {
            interactable = null;
        }
    }
    #endregion

    // Interact
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(interactable != null)
            {
                interactable.Interact();
            }
        }
    }

}
