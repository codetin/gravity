using UnityEngine;
using System.Collections;

public class EnemySquare : Enemy
{
	

	// Use this for initialization
	void Start ()
	{
		//attack = 10;
		attack = GetComponent<Life>().m_Attack;
		player = GameObject.FindGameObjectWithTag ("player");
		m_EnemyMoveDelay = Random.Range (0.5f, 1f);
		m_EnemyStopDelay = Random.Range (0.5f, 1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveMethod ();
		CheckHP();
	}

	public override void Move ()
	{
		transform.LookAt (player.transform);
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
}
