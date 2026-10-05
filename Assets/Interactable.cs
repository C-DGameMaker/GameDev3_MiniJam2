using UnityEngine;
using UnityEngine.InputSystem;

public interface Interactable
{
    public void Action();
    public void Move(InputAction.CallbackContext Context);
}
