using UnityEngine;

/*
Attaches to Main Camera object
Allows it to follow Transforms with offsets
*/

[RequireComponent(typeof(Camera))]
public class GameCamera : MonoBehaviour
{
    [SerializeField] private Transform _cameraTarget;    // Target that the camera will be following
    public Vector3 positionOffset;    // Offset of camera from the target's position
    public float smoothAmount = 0.1f;    // How smoothly camera will go to target position, 0 = instant

    private Vector3 _velocity; // Used to store velocity of camera movement for smoothing
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    public Camera Camera => _camera;

    public void SetCameraTarget (Transform target)
    {
        _cameraTarget = target;
    }
    
    private void LateUpdate()
    {
        // Smoothly move to target + offset
        transform.position = Vector3.SmoothDamp(transform.position, _cameraTarget.transform.position + positionOffset, ref _velocity, smoothAmount);
    }
}
