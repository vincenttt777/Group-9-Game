using UnityEngine;

/*
Attaches to Main Camera object
Allows it to follow Transforms with offsets
*/

public class GameCamera : MonoBehaviour
{
    public Transform cameraTarget;    // Target that the camera will be following
    public Vector3 positionOffset;    // Offset of camera from the target's position
    public float smoothAmount = 0.1f;    // How smoothly camera will go to target position, 0 = instant

    private Vector3 _velocity; // Used to store velocity of camera movement for smoothing

    public PlayerController playerController;

    private void LateUpdate()
    {
        // Smoothly move to target + offset
        transform.position = Vector3.SmoothDamp(transform.position, cameraTarget.transform.position + positionOffset, ref _velocity, smoothAmount);
    }
}
