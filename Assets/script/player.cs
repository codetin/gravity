using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
	
	public float speed = 40;
	public MPJoystick leftstick;
	public MPJoystick rightstick;
	public float angle;
	public float oldangle;
	public Vector2 mousePosition = Vector2.zero;
	public GameObject bullet;
	public int m_Score = 0;
	//public int HP = 100;
	public bool isFire;
	public Object m_tailPre;
	public Transform m_tailPoint;
	protected GameObject tail;
	public GameObject m_explo;
	public Color m_Color;
	// Use this for initialization
	void Start ()
	{
		leftstick.position = Vector2.zero;
		rightstick.position = Vector2.zero;
		//tail = GameObject.FindWithTag ("tail");
		//Instantiate (m_tailPre, m_tailPoint.position, m_tailPoint.rotation);

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (rightstick.position.x != 0 || rightstick.position.y != 0) {
			isFire = true;
			angle = (Mathf.Rad2Deg) * (Mathf.Atan2 (rightstick.position.y, rightstick.position.x));
			//angle= (Mathf.Rad2Deg*Mathf.Atan2(duibian,linbian));
			angle = angle - 90;
			transform.Rotate (0, -(angle - oldangle), 0, Space.World);
			oldangle = angle;
		} else {
			isFire = false;
		}
		//left
		if (leftstick.position.x >= -1 && leftstick.position.x < 0) { 
			transform.Translate (Vector3.left * Time.deltaTime * speed, Space.World);
			//tail.SetActive (true);
			if (tail == null) {
				tail = (GameObject)Instantiate (m_tailPre, m_tailPoint.position, m_tailPoint.rotation);
				tail.transform.parent = this.transform;
			}
		}
		//right
		if (leftstick.position.x <= 1 && leftstick.position.x > 0) { 
			transform.Translate (Vector3.right * Time.deltaTime * speed, Space.World);
			
			if (tail == null) {
				tail = (GameObject)Instantiate (m_tailPre, m_tailPoint.position, m_tailPoint.rotation);
				tail.transform.parent = this.transform;
			}
		}
		//down
		if (leftstick.position.y >= -1 && leftstick.position.y < 0) { 
			transform.Translate (Vector3.back * Time.deltaTime * speed, Space.World);
			
			if (tail == null) {
				tail = (GameObject)Instantiate (m_tailPre, m_tailPoint.position, m_tailPoint.rotation);
				tail.transform.parent = this.transform;
			}
		}
		//up
		if (leftstick.position.y <= 1 && leftstick.position.y > 0) { 
			transform.Translate (Vector3.forward * Time.deltaTime * speed, Space.World);
			
			if (tail == null) {
				tail = (GameObject)Instantiate (m_tailPre, m_tailPoint.position, m_tailPoint.rotation);
				tail.transform.parent = this.transform;
			}
		}
		
		if (leftstick.position.x == 0 && leftstick.position.y == 0) {
			if (tail != null)
				GameObject.Destroy (tail);
		}
		CheckHP ();
	}
	
	void CheckHP ()
	{
		if (GetComponent<Life> ().m_HP <= 0) {
			m_explo.particleSystem.startColor = m_Color;
			GameObject explo = (GameObject)Instantiate (m_explo, transform.position, Quaternion.Euler (0, 0, 0));
			Destroy (explo, 1f);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "enemy")
			Debug.Log ("hited");
		//Destroy(transform.gameObject);
	}
	
}
