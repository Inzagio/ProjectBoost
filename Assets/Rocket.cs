using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	Rigidbody rigidBody;

	AudioSource thrustAudio;
	// Use this for initialization
	void Start()
	{
		rigidBody = GetComponent<Rigidbody>();

		thrustAudio = GetComponent<AudioSource>();
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
			if (!thrustAudio.isPlaying)
			{
				thrustAudio.Play();
			}
			
		}
		else
		{
			thrustAudio.Stop();
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
