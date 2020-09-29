using UnityEngine;

/*
 * Script that spins a transform when used by player, and change colors on selection and deselection
 */

// Class must implement the interface 'Useable' if it can be used by player.
// Will then require the functions OnUse, OnSelect, OnDeselect

public class CubeSpinner : MonoBehaviour, Useable
{
    public float rotateSpeed = 150f; // Speed at which object will spin
    public bool spinning = false; // flag for if the spin should be happening or not
    public Color selectedColor = Color.red; // color the object will turn when selected

    private Color _origColor; // variable to store / restore the object's original color

    // Called when game starts
    private void Start()
    {
        _origColor = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    private void Update()
    {
        if (spinning)
        {
            // Store the current local euler angles (rotation but xyz version)
            var rotation = transform.localEulerAngles;
            
            // Add to the rotation's Y axis by the rotate speed, but multiply by Time.deltaTime so it spins equally on all PCs faster or slower.
            rotation.y = rotation.y + (rotateSpeed * Time.deltaTime);
            
            // Set the new rotation to the transform's local euler angle rotation
            transform.localEulerAngles = rotation;
        }
    }

    public void OnUse()
    {
        // Toggle spinning on use
        spinning = !spinning;
    }

    public void OnSelect()
    {
        GetComponent<Renderer>().material.color = selectedColor; // Make object colored on player selection
    }

    public void OnDeselect()
    {
        GetComponent<Renderer>().material.color = _origColor; // Return to original color on player de-selection
    }
}
