using UnityEngine;

/*
Controls the player input and moves character on screen
*/

// this is cade, testing the github usage

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Animator animator;    // Where to send animation data to
    public float _moveSpeed = 5f;    // How fast player will move
    
    private CharacterController _characterController;
    private Vector3 _facingDirection = Vector3.back;
    private Vector3 _moveVector;
    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Get player input data
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.z = Input.GetAxis("Vertical");
        
        // Prevent movement from exceeding a factor of 1, useful for diagonals.
        _moveVector = Vector3.ClampMagnitude(_moveVector, 1f);

        // If moving, change the facing direction
        if (_moveVector != Vector3.zero)
        {
            _facingDirection = _moveVector.normalized;
        }

        // Update the character controller to perform the move
        _characterController.SimpleMove(_moveVector * _moveSpeed);
        
        // Send animator the movement data for visuals
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("x", _facingDirection.x);
        animator.SetFloat("y", _facingDirection.z);
        animator.SetFloat("speed", _moveVector.magnitude);
    }
}
