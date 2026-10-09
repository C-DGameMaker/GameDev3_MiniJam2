using UnityEngine;
using UnityEngine.InputSystem;

public interface Possessable
{
    public void Action();
    public void Move(InputAction.CallbackContext Context);
}
