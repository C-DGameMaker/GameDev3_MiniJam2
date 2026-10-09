using UnityEngine;
using UnityEngine.Rendering;

public class Interactable_Possess : MonoBehaviour, IInteractable
{ 
    public void Interact()
    {
        // Check to see if the player can possess, if so, possess the object, if not, tells them

        Debug.Log("Can Interact");
       
    }
}
