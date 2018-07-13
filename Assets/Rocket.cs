using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	Rigidbody rigidBody;
	// Use this for initialization
	void Start()
	{
		rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		ProcessInput();
	}

	private void ProcessInput()
	{
		// Apply thrust
		if (Input.GetKey(KeyCode.Space))
		{
			rigidBody.AddRelativeForce(Vector3.up);
		}
		//Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			//transform.Rotate((Vector3.forward) * Time.deltaTime);
			transform.Rotate(Vector3.forward);
		}
		//Rotate right
		else if (Input.GetKey(KeyCode.D))
		{
			//transform.Rotate((Vector3.back) * Time.deltaTime);
			transform.Rotate(-Vector3.forward);
		}
	}
}
