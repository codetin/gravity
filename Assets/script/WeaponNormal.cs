using UnityEngine;
using System.Collections;

public class WeaponNormal : Weapon
{
	private const int MAX_FP = 1;
	public Transform[] m_FirePoint = new Transform[MAX_FP];
	public Object m_BulletPre;
	
	WeaponNormal ()
	{
		m_fBulletInterval = 0.2f;
		m_typeName = "Normal";
	}
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public override void Fire ()
	{
		for (int i = 0; i < MAX_FP; i++) {
			Object clone = Instantiate (m_BulletPre, m_FirePoint [i].position,
                        m_FirePoint [i].rotation);
            
			//clone.velocity = transform.TransformDirection (Vector3.up*20);
			//clone.transform.Translate(Vector3.up * 100);
		}
	}
}
