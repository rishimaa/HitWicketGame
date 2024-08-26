using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target that the camera will follow
    public Vector3 offset; // The offset from the target's position
    public float smoothSpeed = 0.125f; // How smoothly the camera follows

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target); // Optional: to keep the camera looking at the target
    }
}
