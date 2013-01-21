using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	
	public Object m_EnemyPre;
	public Object[] m_Enemys;
	public float m_EnemyInterval = 1;
	public float m_EnemyElapseTime = 0; 
	// Use this for initialization
	void Start ()
	{
		//PlayerPrefs.SetInt("key",10);
	}
	
	// Update is called once per frame
	void Update ()
	{
		m_EnemyElapseTime += Time.deltaTime;
		if (m_EnemyElapseTime > m_EnemyInterval) {
			CreateEnemy (Random.Range(3,5));
			m_EnemyElapseTime = 0;
		}
		
	
		if (Application.platform == RuntimePlatform.Android && (Input.GetKeyDown (KeyCode.Escape))) {
			Application.Quit ();
		}

		
	}
	
	void CreateEnemy (int m_EnemyNumber)
	{
		int m_CreateSide = Random.Range (1, 5);
		int m_EnemyKind = Random.Range (0, m_Enemys.Length);
		Vector3 position = Vector3.zero;
		for (int i=0; i<m_EnemyNumber; i++) {
			switch (m_CreateSide) {
			//up
			case 1:
				position = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (0, Screen.width), Screen.height, Camera.main.transform.position.y - 10));	
				break;
			//down
			case 2:
				position = Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range (0, Screen.width), 0, Camera.main.transform.position.y - 10));
				break;
			//left
			case 3:
				position = Camera.main.ScreenToWorldPoint (new Vector3 (0, Random.Range (0, Screen.height), Camera.main.transform.position.y - 10));
				break;
			//right
			case 4:
				position = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Random.Range (0, Screen.height), Camera.main.transform.position.y - 10));
				break;
			}
			Object Enemy = Instantiate (m_Enemys [m_EnemyKind], position, Quaternion.Euler (0, 0, 0));
		}
	}
	
	void OnGUI ()
	{
		GUILayout.BeginArea (new Rect (0, 0, Screen.width, 50));
		GUILayout.BeginHorizontal ();
		GUILayout.Box ("HP ");
		GUILayout.FlexibleSpace ();
		GUILayout.Box ("Score");
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();
		
	}
	
}
