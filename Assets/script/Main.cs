using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	public GameObject player;
	public Object m_EnemyPre;
	public Object[] m_Enemys;
	public float m_EnemyInterval = 1;
	public float m_EnemyElapseTime = 0;
	public GUISkin guiskin;
	// Use this for initialization
	void Start ()
	{
		//PlayerPrefs.SetInt("key",10);
		//player=GameObject.FindWithTag("player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		m_EnemyElapseTime += Time.deltaTime;
		if (m_EnemyElapseTime > m_EnemyInterval) {
			CreateEnemy (Random.Range (3, 5));
			m_EnemyElapseTime = 0;
		}
		
	
		if (Application.platform == RuntimePlatform.Android && (Input.GetKeyDown (KeyCode.Escape))) {
			Application.Quit ();
		}
		
		
	}
	
	void CreateEnemy (int m_EnemyNumber)
	{
		float m_widthPos = 0;
		float m_heightPos = 0;
		float m_oldWidthPos = 0;
		float m_oldHeightPos = 0;
		int m_CreateSide = Random.Range (1, 5);
		int m_EnemyKind = Random.Range (0, m_Enemys.Length);
		Vector3 position = Vector3.zero;
		Vector3 m_playerPos = Camera.main.WorldToScreenPoint (player.transform.position);
		for (int i=0; i<m_EnemyNumber; i++) {
			if (Random.Range (0, 2)==0) {
				switch (m_CreateSide) {
				//up
				case 1:
					m_heightPos = Screen.height;
					while (m_widthPos-m_oldWidthPos<10 && m_widthPos-m_oldWidthPos>-10) {
						m_widthPos = Random.Range (0, Screen.width);
					}
					m_oldWidthPos = m_widthPos;
				//position = Camera.main.ScreenToWorldPoint (new Vector3 (m_widthPos, m_heightPos, Camera.main.transform.position.y - 10));	
					break;
				//down
				case 2:
				
					m_heightPos = 0;
					while (m_widthPos-m_oldWidthPos<10 && m_widthPos-m_oldWidthPos>-10) {
						m_widthPos = Random.Range (0, Screen.width);
					}
					m_oldWidthPos = m_widthPos;
				//position = Camera.main.ScreenToWorldPoint (new Vector3 (, 0, Camera.main.transform.position.y - 10));
					break;
				//left
				case 3:
					m_widthPos = 0;

					while (m_heightPos-m_oldHeightPos<10 && m_heightPos-m_oldHeightPos>-10) {
						m_heightPos = Random.Range (0, Screen.height);
					}
					m_oldHeightPos = m_heightPos;
				//position = Camera.main.ScreenToWorldPoint (new Vector3 (0, , Camera.main.transform.position.y - 10));
					break;
				//right
				case 4:
					m_widthPos = Screen.width;
					while (m_heightPos-m_oldHeightPos<10 && m_heightPos-m_oldHeightPos>-10) {
						m_heightPos = Random.Range (0, Screen.height);
					}
					m_oldHeightPos = m_heightPos;
				//position = Camera.main.ScreenToWorldPoint (new Vector3 (, , Camera.main.transform.position.y - 10));
					break;
				}
			} else {
				Rect deadRect = new Rect (m_playerPos.x - 200, m_playerPos.y - 200, 400f, 400f);
				do {
					m_heightPos = Random.Range (0, Screen.height);
					m_widthPos = Random.Range (0, Screen.width);
				} while(deadRect.Contains(new Vector2(m_widthPos,m_heightPos)));
			}
			position = Camera.main.ScreenToWorldPoint (new Vector3 (m_widthPos, m_heightPos, Camera.main.transform.position.y - 10));
			Instantiate (m_Enemys [m_EnemyKind], position, Quaternion.Euler (0, 0, 0));
			
		}
	}
	
	void OnGUI ()
	{
		GUI.skin = guiskin;
		GUILayout.BeginArea (new Rect (0, 0, Screen.width, 50));
		GUILayout.BeginHorizontal ();
		GUILayout.Box ("HP " + player.GetComponent<Life> ().m_HP);
		GUILayout.FlexibleSpace ();
		GUILayout.Box ("Score" + player.GetComponent<player> ().m_Score);
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();
		
	}
	
}
