using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObstacle : MonoBehaviour
{

    public float Speed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * Speed);
	}
}
