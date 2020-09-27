using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTest : MonoBehaviour, Interactable
{
    public bool open = false;
    public float doorSpeed = 2f;

    private Vector3 _closedPosition;

    private void Start()
    {
        _closedPosition = transform.position;
    }

    public void OnUse()
    {
        open = !open;
    }

    private void Update()
    {
        Vector3 targetPos;
        
        if (open)
        {
            targetPos = new Vector3(transform.position.x, _closedPosition.y - 1.45f, transform.position.z);
        }
        else
        {
            targetPos = _closedPosition;
        }

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * doorSpeed);
    }

}
