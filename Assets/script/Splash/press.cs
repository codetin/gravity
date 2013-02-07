using UnityEngine;
using System.Collections;

public class press : MonoBehaviour
{
    protected float m_ElapseTime = 0;
    protected float m_Interval = 1;
    protected GameObject m_Title;
    // Use this for initialization
    void Start()
    {
        m_Title = GameObject.FindGameObjectWithTag("title");
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnGUI()
    {
        if (Application.platform == RuntimePlatform.Android && (Input.GetKeyDown(KeyCode.Escape)))
        {
            Application.Quit();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel(1);
        }
        m_ElapseTime += Time.deltaTime;
        if (m_ElapseTime > m_Interval && m_Title.activeInHierarchy == true)
        {
            //gameObject.transform.Translate(new Vector3(0f, 0f, -1f));
            m_Title.SetActive(false);
            m_ElapseTime = 0;
        }
        else if (m_ElapseTime > m_Interval && m_Title.activeInHierarchy == false)
        {
            m_ElapseTime = 0;
            //gameObject.transform.Translate(new Vector3(0f, 0f, 1f));
            m_Title.SetActive(true);

        }
    }
}
