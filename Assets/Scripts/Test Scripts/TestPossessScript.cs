using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPossessScript : MonoBehaviour
{
    
    public Possessable possessedObject;
    private IInteractable currentInteractable;

    private Possessable currentPossessable;
    public void Move(InputAction.CallbackContext context)
    {
        //add to control move
        if (possessedObject != null)
        {
            possessedObject.Move(context);
        }
        else
        {
            //add normal movement here
        }
    }
    public void Action(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (possessedObject != null)
            {
                //triggers action of possessed object
                possessedObject.Action();
            }
            else if (currentInteractable != null)
            {
                //if not possessing an object trigger interactable object
                currentInteractable.Interact();
            }
        }
    }
    
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable foundInteractable))
        {
            currentInteractable = foundInteractable;
            Debug.Log(currentInteractable);



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
            currentInteractable = null;



        }
        if (other.TryGetComponent(out Possessable foundPossessable))
        {
            currentPossessable = null;
        }
    }
}
