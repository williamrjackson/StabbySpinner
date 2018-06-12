using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
    private float m_TimeToChange = .5f;
    private Button m_Button;
    void Start () {
        GameManager.instance.OnWin += Win;
        GameManager.instance.OnGameOver += GameOver;
        m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(Clicked);
    }
    
    void Clicked()
    {
        GameManager.instance.NewGame();
    }
    void Win()
    {
        GetComponent<Image>().color = Color.green;
        GameManager.instance.IncrementLevel();
        StartCoroutine(ScaleIn());
    }

    void GameOver()
    {
        GetComponent<Image>().color = Color.red;
        StartCoroutine(ScaleIn());
    }

    IEnumerator ScaleIn()
    {
        float elapsedTime = 0;
        while (elapsedTime < m_TimeToChange)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            float scaleMagnitude = Mathf.Lerp(0, 1, Mathf.InverseLerp(0, m_TimeToChange, elapsedTime));
            transform.localScale = new Vector3(scaleMagnitude, scaleMagnitude, scaleMagnitude);
        }
        transform.localScale = new Vector3(1, 1, 1);
    }
}
