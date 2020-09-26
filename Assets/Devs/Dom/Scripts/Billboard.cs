using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Billboard : MonoBehaviour
{
	private Transform _camTransform;

	public void Awake()
	{
		_camTransform = Camera.main.transform;
	}
	
    void LateUpdate()
    {
	    Vector3 newAngles = transform.eulerAngles;
	    newAngles.y = _camTransform.eulerAngles.y;
	    transform.eulerAngles = newAngles;
    }
}
