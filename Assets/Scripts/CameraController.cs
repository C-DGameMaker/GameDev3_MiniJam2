using UnityEngine;
using UnityEngine.Rendering;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5;
    public Vector3 offset;
    private void Start()
    {
        offset = transform.position;
    }

    public void RotateCamera()
    {

    }
    private void LateUpdate()
    {
        Vector3 move = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, move, smoothSpeed * Time.deltaTime);
    }



}
