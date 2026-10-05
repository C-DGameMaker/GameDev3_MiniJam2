using UnityEngine;
using UnityEngine.InputSystem;

public interface Possesable
{
    public void Action();
    public void Move(InputAction.CallbackContext Context);
}
