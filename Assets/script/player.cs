using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{
	
	public float speed = 10;
	public MPJoystick leftstick;
	public MPJoystick rightstick;
	public float angle;
	public float oldangle;
	public Vector2 mousePosition = Vector2.zero;
	public GameObject bullet;
	//public int HP = 100;
	public bool isFire;
	
	// Use this for initialization
	void Start ()
	{
		leftstick.position=Vector2.zero;
		rightstick.position=Vector2.zero;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (joyr == null)
//			Debug.Log ("no joyr");
//		if (joyr.AxisX != 0 || joyr.AxisY != 0) {
//			isFire = true;
//			angle = (Mathf.Rad2Deg) * (Mathf.Atan2 (joyr.AxisY, joyr.AxisX));
//			//angle= (Mathf.Rad2Deg*Mathf.Atan2(duibian,linbian));
//			angle = angle - 90;
//			transform.Rotate (0, 0, angle - oldangle, Space.World);
//			oldangle = angle;
//		} else {
//			isFire = false;
//		}
//
//		if (joyl.AxisX >= -1 && joyl.AxisX < 0) { 
//			transform.Translate (Vector3.left * Time.deltaTime * speed, Space.World);
//		}
//
//		if (joyl.AxisX <= 1 && joyl.AxisX > 0) { 
//			transform.Translate (Vector3.right * Time.deltaTime * speed, Space.World);
//		}
//		
//		if (joyl.AxisY >= -1 && joyl.AxisY < 0) { 
//			transform.Translate (Vector3.down * Time.deltaTime * speed, Space.World);
//		}
//
//		if (joyl.AxisY <= 1 && joyl.AxisY > 0) { 
//			transform.Translate (Vector3.up * Time.deltaTime * speed, Space.World);
//		}

		if (rightstick.position.x != 0 || rightstick.position.y != 0) {
			isFire = true;
			angle = (Mathf.Rad2Deg) * (Mathf.Atan2 (rightstick.position.y, rightstick.position.x));
			//angle= (Mathf.Rad2Deg*Mathf.Atan2(duibian,linbian));
			angle = angle - 90;
			transform.Rotate (0, -(angle - oldangle), 0 , Space.World);
			oldangle = angle;
		} else {
			isFire = false;
		}
		//left
		if (leftstick.position.x >= -1 && leftstick.position.x < 0) { 
			transform.Translate (Vector3.left * Time.deltaTime * speed, Space.World);
		}
		//right
		if (leftstick.position.x <= 1 && leftstick.position.x > 0) { 
			transform.Translate (Vector3.right * Time.deltaTime * speed, Space.World);
		}
		//down
		if (leftstick.position.y >= -1 && leftstick.position.y < 0) { 
			transform.Translate (Vector3.back * Time.deltaTime * speed, Space.World);
		}
		//up
		if (leftstick.position.y <= 1 && leftstick.position.y > 0) { 
			transform.Translate (Vector3.forward * Time.deltaTime * speed, Space.World);
		}
		
		/*
		if (Input.GetMouseButton(0)){
			GameObject bullet = GameObject.Find("bullet");
			Instantiate(bullet,bullet.transform.position,bullet.transform.rotation);
		}
		*/	
		CheckHP ();
	}
	
	void CheckHP ()
	{
		if (GetComponent<Life> ().m_HP <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "enemy")
			Debug.Log ("hited");
		//Destroy(transform.gameObject);
	}
	
	void OnGUI ()
	{
		GUI.Label(new Rect(20,20,200,20),angle.ToString());
		GUI.Label (new Rect (20, 50, 200, 20), leftstick.position.x + " " + leftstick.position.y);
		GUI.Label (new Rect (20, 70, 200, 20), rightstick.position.x + " " + rightstick.position.y);
		//(Mathf.Rad2Deg*Mathf.Atan2(10,5)).ToString()
	}
}
