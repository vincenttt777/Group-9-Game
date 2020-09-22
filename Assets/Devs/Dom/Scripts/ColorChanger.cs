using UnityEngine;

public class ColorChanger : MonoBehaviour, Interactable
{
    public void OnUse()
    {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
