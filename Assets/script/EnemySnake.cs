using UnityEngine;
using System.Collections;

public class EnemySnake : Enemy
{

	// Use this for initialization
	void Start ()
	{
		//attack = 20;
		attack = GetComponent<Life>().m_Attack;
		player = GameObject.FindGameObjectWithTag ("player");
		m_EnemyStopDelay = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveMethod ();
		CheckHP ();
	}

	public override void Move ()
	{
		transform.LookAt (player.transform);
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
}
