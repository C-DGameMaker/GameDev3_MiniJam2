using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Charlie Dobson - makes the camera follow the player
/// </summary>
public class CameraController : MonoBehaviour
{
    [Header("Stuff that needs to be seen")]
    public Transform player;
    public Vector3 offset;
    public float rotateSpeed = 5f;
    public float distanceFromPlayer = 5f; 

    // The other techincal stuff
    private float currentAngle; 
    private Vector2 rotationInput;

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

        // This ensure the camera is always looking at the player
        transform.LookAt(player);
    }

}
