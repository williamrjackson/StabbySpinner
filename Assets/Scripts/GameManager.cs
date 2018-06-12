using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public UnityAction OnGameOver;
    public UnityAction OnWin;
    private bool m_IsGameOver = false;
    private int m_Level = 1;
    // Use this for initialization
    void Awake() {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void NewGame()
    {
        m_IsGameOver = false;
        OnWin = null;
        OnGameOver = null;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BroadcastGameOver()
    {
        m_IsGameOver = true;
        if (OnGameOver != null)
        {
            OnGameOver();
        }

    }
    public void BroadcastWin()
    {
        m_IsGameOver = true;
        if (OnWin != null)
        {
            OnWin();
        }
    }
    public bool GetGameOver()
    {
        return m_IsGameOver;
    }
    public void IncrementLevel()
    {
        m_Level++;
    }
    public int GetLevel()
    { 
        return m_Level;
    }
}
