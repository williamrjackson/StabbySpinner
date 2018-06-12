using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpinner : MonoBehaviour {
    public Vector3 rotationPerSecond = Vector3.zero;
    private bool m_IsSpinning = true;
    void Start()
    {
        GameManager.instance.OnGameOver += GameOver;
    }
    void GameOver()
    {
        m_IsSpinning = false;
    }
    void Update () {
        if (m_IsSpinning)
            transform.Rotate(rotationPerSecond * Time.deltaTime);
	}
}
