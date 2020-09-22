using UnityEngine;

/*
 * This script causes an object to change to a random color when player steps on it.
 */

public class ColorChangePad : MonoBehaviour
{
    // IMPORTANT: For this function to work, object needs a collider that is set to 'trigger'.
    public void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the tag 'Player'
        if (other.gameObject.tag == "Player")
        {
            // Change color to random color
            GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
        }
    }
}
