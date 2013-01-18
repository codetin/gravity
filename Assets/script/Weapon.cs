using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

	protected float m_fBulletInterval = 0;
	public string m_typeName = "";
	
	public float GetBulletInterval ()
	{
		return m_fBulletInterval;
	}
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public virtual void Fire ()
	{
        
	}
}
