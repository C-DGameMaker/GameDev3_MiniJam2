using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour, Possessable
{
    public Camera Cam;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cam = FindAnyObjectByType<Camera>();
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
        Vector3 move3d = new Vector3(move.x, 0, move.y) * speed * Time.deltaTime;
        move3d = Quaternion.Euler(0, Cam.transform.eulerAngles.y, 0) * move3d;
        rb.AddForce(move3d * speed);
    }
}
