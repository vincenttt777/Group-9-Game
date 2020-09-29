using UnityEngine;

public class ColorChanger : MonoBehaviour, Useable
{
    public void OnUse()
    {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    public void OnSelect()
    {
        throw new System.NotImplementedException();
    }

    public void OnDeselect()
    {
        throw new System.NotImplementedException();
    }
}

