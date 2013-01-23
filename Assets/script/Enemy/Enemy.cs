using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public GameObject player;
	public int speed = 15;
	public int attack ;
	public float m_EnemyMoveDelay = 1;
	public float m_EnemyStopDelay = 0.5f;
	protected float m_ElapseTime = 0;
	protected int m_MoveFlag = 0;
	public GameObject m_explo;
	public Color m_Color;
	// Use this for initialization
	void Start ()
	{
		attack = GetComponent<Life> ().m_Attack;
		player = GameObject.FindGameObjectWithTag ("player");
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveMethod ();
		CheckHP ();
	}
	
//	public void OnTriggerEnter (Collider other)
//	{
//		if (other.tag == "bullet")
//			Destroy (transform.gameObject);
//	}
	
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "player") {
			player.GetComponent<Life> ().m_HP = player.GetComponent<Life> ().m_HP - attack;
			//Debug.Log (player.GetComponent<Life> ().m_HP);
		}
	}
	
	public void CheckHP ()
	{
		if (GetComponent<Life> ().m_HP <= 0) {
			player.GetComponent<player> ().m_Score += GetComponent<Life> ().m_Score;
			m_explo.particleSystem.startColor=m_Color;
			GameObject explo = (GameObject)Instantiate (m_explo, transform.position, Quaternion.Euler (0, 0, 0));
			Destroy (explo, 1f);
			Destroy (gameObject);
		}
	}
	
	public void MoveMethod ()
	{
		m_ElapseTime += Time.deltaTime;
		//move to stop
		if (m_MoveFlag == 1) {
			if (m_ElapseTime > m_EnemyMoveDelay) {
				m_MoveFlag = 0;
				m_ElapseTime = 0;
			} else {
				Move ();
			}
		}
		//stop to move
		if (m_MoveFlag == 0) {
			if (m_ElapseTime > m_EnemyStopDelay) {
				m_MoveFlag = 1;
				m_ElapseTime = 0;
			}
		}
	}

	public virtual void Move ()
	{
		transform.LookAt (player.transform);
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
}
