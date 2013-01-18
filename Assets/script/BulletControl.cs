using UnityEngine;
using System.Collections;

public class BulletControl : MonoBehaviour
{
	public int attack;
	public float m_Speed = 5f;
	// Use this for initialization
	void Start ()
	{
		attack = GetComponent<Life> ().m_Attack;
	}
	
	// Update is called once per frame
	void Update ()
	{

		Vector3 screenPos = Camera.mainCamera.WorldToScreenPoint (this.transform.position);
		if (Screen.height < screenPos.y || Screen.width < screenPos.x)
			Destroy (transform.gameObject);
		if (0 > screenPos.y || 0 > screenPos.x)
			Destroy (transform.gameObject);

	}

	void FixedUpdate ()
	{
		transform.Translate (Vector3.forward * m_Speed);
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "enemy") {
			other.gameObject.GetComponent<Life> ().m_HP = other.gameObject.GetComponent<Life> ().m_HP - attack;
			//Debug.Log (other.GetComponent<player> ().HP);
		}
		//Destroy (other.transform.gameObject);
		Destroy (transform.gameObject, 0.02f);
	}

}
