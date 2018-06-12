using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {
    private TextMesh m_TextMesh;
    private int m_Count;
	// Use this for initialization
	void Start () {
        m_TextMesh = GetComponent<TextMesh>();
        m_Count = GameManager.instance.GetLevel() + 5;
        m_TextMesh.text = m_Count.ToString();
	}

    public void Decrease()
    {
        --m_Count;
        m_TextMesh.text = m_Count.ToString();
        if (m_Count <= 0)
        {
            GameManager.instance.BroadcastWin();
        }
    }
}
