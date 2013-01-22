using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
	public Weapon m_CurWeapon;
	public player player;
	private float m_FireElapseTime = 0; 
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		m_FireElapseTime += Time.deltaTime;
		//if (Input.GetKey (KeyCode.Space)) {
		if (player.isFire) {
			if (m_FireElapseTime > m_CurWeapon.GetBulletInterval ()) {
				m_CurWeapon.Fire ();
				m_FireElapseTime = 0;
			}
		}
	}
}
