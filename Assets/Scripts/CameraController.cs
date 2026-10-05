using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Rotating Camera

    public float rotateSpeed = 5f;
    private Vector2 rotationInput;
    public float distanceFromPlayer = 5f; 
    private float currentAngle;

    private void Start()
    {
        offset = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RotateCamera(InputAction.CallbackContext context)
    {
        rotationInput = context.ReadValue<Vector2>();
    }

    public void Update()
    {
        currentAngle += rotationInput.x * rotateSpeed * Time.deltaTime;

        Vector3 cameraOffset = Quaternion.Euler(0f, currentAngle, 0f) * offset * distanceFromPlayer;

        transform.position = player.position + cameraOffset;
        transform.LookAt(player.position);
    }

}
