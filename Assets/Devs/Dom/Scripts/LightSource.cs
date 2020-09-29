using UnityEngine;

/*
 * This script is a test for base interactivity using lights
 */

// RequireComponent is a handy way to make sure Unity object with this script
// will always has a component. GetComponent<Light>() will never throw a null error in code
[RequireComponent(typeof(Light))]

public class LightSource : MonoBehaviour, Useable
{
    // Boolean for the state of the light, public so it can be set in inspector
    public bool lightActive = false;
    
    // Reference variable for Unity light component
    private Light _light;

    // These must be set in the inspector, drag the objects onto the fields.
    public GameObject onObject;
    public GameObject offObject;

    
    // Unity calls this before anything at all happens in game
    private void Awake()
    {
        // Get the component reference to modify later as variable, faster than calling GetComponent every time
        _light = GetComponent<Light>();
        
        SetLightActive(lightActive); // Set the initial state of the light to begin with
    }
    

    // IMPORTANT! This is an override of the Interactable OnUse function that the player can call on the object
    public void OnUse()
    {
        lightActive = !lightActive;  // Flip the light's boolean on/off state
        SetLightActive(lightActive); // Set the light's new state
    }

    public void OnSelect()
    {
        throw new System.NotImplementedException();
    }

    public void OnDeselect()
    {
        throw new System.NotImplementedException();
    }


    private void SetLightActive(bool active)
    {
        // Set the unity light source
        _light.enabled = active;
        
        // Check we even have an onObject to set, prevents a null error.
        if (onObject != null)
        {
            // Enable or disable the 'light is on' visual object
            onObject.SetActive(active);
        }

        // Check we even have an offObject to set, prevents a null error
        if (offObject != null)
        {
            // Enable or disable the 'light is off' visual object
            offObject.SetActive(!active);
        }
    }
}
