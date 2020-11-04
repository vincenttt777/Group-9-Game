using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveIce : MonoBehaviour
{
    public GameObject ice;

    // Start is called before the first frame update
    void Start()
    {
        ice = GameObject.Find("Ice/Ice");
        ice.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        ice.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        ice.SetActive(false);
    }
}
