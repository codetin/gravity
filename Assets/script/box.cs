using UnityEngine;
using System.Collections;

public class box : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		GameObject box = GameObject.Find ("Cube");
		//box.rigidbody.velocity = transform.TransformDirection (Vector3.up*20);

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnTriggerEnter ()
	{
		Destroy (transform.gameObject);
	}
}
