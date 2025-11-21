using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform target;
    public float smoothSpeed = 5f;
    public Vector3 offset;

    // LateUpdate is called after all update functions
    void LateUpdate()
    {
        // Where we want the camera to be
        Vector3 desiredPos = target.position + offset;
        // How we are going to get there smoothly
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        // Force the Z axis as -10 to stop the camera moving on all axis
        smoothedPos.z = -10;
        transform.position = smoothedPos;
    }
}
