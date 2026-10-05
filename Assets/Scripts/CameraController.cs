using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5;
    public Vector3 offset;

    // Rotating Camera

    public float rotateSpeed = 5;
    private Vector2 rotationInput;
    public float rotationSpeed = 5f; // Sensitivity multiplier
    public float distanceFromPlayer = 5f; // Camera distance
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
        currentAngle += rotationInput.x * rotationSpeed * Time.deltaTime;

        Vector3 offset = Quaternion.Euler(0f, currentAngle, 0f) * Vector3.back * distanceFromPlayer;

        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }

    private void LateUpdate()
    {
        Vector3 move = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, move, smoothSpeed * Time.deltaTime);
    }



}
