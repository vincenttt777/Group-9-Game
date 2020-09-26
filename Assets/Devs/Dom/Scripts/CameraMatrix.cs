using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[ExecuteInEditMode]
public class CameraMatrix : MonoBehaviour {

	private Camera _cam;
	private float lastRotX = 0f;
	private float lastFov = 0;
	public bool reflectionMatrix = false;
	public bool custom = false;
	public Matrix4x4 customMatrix;
	

	void OnEnable () {
		_cam = GetComponent<Camera>();
		SetProperMatrix();
		customMatrix = _cam.projectionMatrix;
	}

	void Start () {
		_cam = GetComponent<Camera>();
		SetProperMatrix();
	}

	private void Update()
	{
		if(transform.eulerAngles.x != lastRotX || _cam.fieldOfView != lastFov || custom)
			SetProperMatrix ();
	}
	
	public float amount = 0.6125f;

	public void SetProperMatrix () {
		_cam.ResetProjectionMatrix();
		Matrix4x4 m = _cam.projectionMatrix;
		if(custom) {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -45f);
			m = customMatrix;
		} else {
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
			m.m11 *= 1f/(Mathf.Cos(transform.eulerAngles.x * amount * Mathf.Deg2Rad));
		}
		_cam.projectionMatrix = m;
	}
}
