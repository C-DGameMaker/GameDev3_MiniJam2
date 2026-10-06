using UnityEngine;
using UnityEngine.InputSystem;

public class Broom : MonoBehaviour,Possessable
{
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Action()
    {
        Debug.Log("interacted with " + this);
    }
    Vector2 move;
    public float speed = 4;
    public Rigidbody rb;
    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        Debug.Log("getting movement");
    }
    private void FixedUpdate()
    {
        Vector3 move3d = new Vector3(move.x, 0, move.y);
        rb.AddForce(move3d * speed);
    }
}
