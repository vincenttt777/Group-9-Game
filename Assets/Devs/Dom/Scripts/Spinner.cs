using UnityEngine;

/*
 * Script that spins object on use by player
 */

// Class must use the interface Interactable if it can be used by player. Done by adding a comma
public class Spinner : MonoBehaviour, Interactable
{
    public float rotateSpeed = 150f; // Speed at which object will spin
    
    private bool _spinning = false; // flag for if the spin should be happening or not

    // Update is called once per frame
    void Update()
    {
        if (_spinning)
        {
            // Create a new rotation on the Y axis by grabbing Euler Angles, and adding to the Y axis.
            // Because this happens every frame we need to multiply by Time.deltaTime so that it won't spin faster on a faster PC.
            var newRotation =  new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + rotateSpeed * Time.deltaTime, transform.localEulerAngles.z);
            
            // Set the new rotation to the transform's local euler angle rotation
            transform.localEulerAngles = newRotation;
        }
    }

    public void OnUse()
    {
        // Toggle spinning on use
        _spinning = !_spinning;
    }
}
