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
    public GameObject possessFX;
    public GameObject activePossessFX;

    public GameObject interactPopUp;

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

        interactPopUp.SetActive(false);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (possessedObject != null)
        {
            possessedObject.Move(context);
            movementInput = Vector2.zero;
        }
        else
        {
            movementInput = context.ReadValue<Vector2>();
        }
        

    }

    private void Update()
    {
        HandlePlayerMovement();
        //sets partical effects postion to current target possessable, if there is none then hides effect
        if(possessedObject == null && currentPossessable != null)
        {
            possessFX.SetActive(true);
            possessFX.transform.position =  currentPossessableGO.transform.position;
        }
        else if(possessFX.activeSelf)
        {
            possessFX.SetActive(false);
        }
        if(possessedObject != null)
        {
            activePossessFX.SetActive(true);
            activePossessFX.transform.position = possessedObjectGO.transform.position;
        }
        else if (activePossessFX.activeSelf)
        {
            activePossessFX.SetActive(false);
        }
    }

    private void HandlePlayerMovement()
    {
        Vector3 move = new Vector3(movementInput.x, 0 , movementInput.y) * movementSpeed * Time.deltaTime;
        move = Quaternion.Euler(0, Cam.transform.eulerAngles.y, 0) * move;
        playerRB.MovePosition(playerRB.position + move);
    }

    public void PauseToggle()
    {
        if (ServiceHubManager.Instance.gameStateManager.currentState == GameStates.Gameplay)
        {
            if (ServiceHubManager.Instance.gameStateManager.currentState == GameStates.Paused) return;
            ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.Paused);
        }
        else if (ServiceHubManager.Instance.gameStateManager.currentState == GameStates.Paused)
        {
            if (ServiceHubManager.Instance.gameStateManager.currentState == GameStates.Gameplay) return;
            ServiceHubManager.Instance.gameStateManager.SwitchGameStates(GameStates.Gameplay);
        }

    }

    #region Trigger Enter/Exit
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IInteractable foundInteractable))
        {
            interactable = foundInteractable;
            interactPopUp.SetActive(true);
        }
        if (other.TryGetComponent(out Possessable foundPossessable))
        {
            currentPossessable = foundPossessable;
            currentPossessableGO = other.gameObject;
            Debug.Log(currentPossessable);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable foundInteractable))
        {
            interactable = null;
            interactPopUp.SetActive(false);
        }
        if (other.TryGetComponent(out Possessable foundPossessable))
        {
            currentPossessable = null;
            currentPossessableGO = null;
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
    private GameObject possessedObjectGO;

    private Possessable currentPossessable;
    private GameObject currentPossessableGO;
    

    public void Possess(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (possessedObject != null)
            {
                //if already possessing object stops possessing it
                Debug.Log("Stopped possessing" + possessedObject);
                possessedObject = null;
                possessedObjectGO = null;
            }
            else if (currentPossessable != null)
            {
                //if possessable is in range then possess object
                Debug.Log("possessed " + currentPossessable);
                possessedObject = currentPossessable;
                possessedObjectGO = currentPossessableGO;
            }
        }
    }
    


    
}
