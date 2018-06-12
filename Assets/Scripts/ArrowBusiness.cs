using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBusiness : MonoBehaviour {
    public float arrowForce = 5;
    private Transform m_SpinnerTransform;
    private Rigidbody2D m_RigidBody;
    private Vector3 m_InitialPosition;
    private Quaternion m_InitialRotation;
    private Vector3 m_InitialLocalScale;
    private bool m_IsFired = false;
    private bool m_IsStuck = false;
    private bool m_IsGameOver = false;
    private CountDown m_CountDown;
	// Use this for initialization
	void Start () {
        m_RigidBody = GetComponent<Rigidbody2D>();
        m_SpinnerTransform = GameObject.FindGameObjectWithTag("Spinner").transform;
        m_CountDown = GameObject.FindObjectOfType<CountDown>();
        m_InitialPosition = transform.position;
        m_InitialRotation = transform.rotation;
        m_InitialLocalScale = transform.localScale;
        GameManager.instance.OnWin += Win;
    }

    void Win()
    {
        m_RigidBody.simulated = true;
        m_RigidBody.constraints = RigidbodyConstraints2D.None;
        m_RigidBody.AddForce(-transform.up * arrowForce, ForceMode2D.Impulse);
        StartCoroutine(Kill());

    }
    // Update is called once per frame
    void Update () {
		if  (!m_IsFired && !GameManager.instance.GetGameOver() && Input.GetMouseButtonDown(0))
        {
            m_RigidBody.AddForce(transform.up * arrowForce, ForceMode2D.Impulse);
        }
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!m_IsStuck && col.gameObject.tag == "Arrow")
        {
            GameManager.instance.BroadcastGameOver();
        }
        else if (col.gameObject.tag == "Spinner")
        {
            transform.parent = m_SpinnerTransform;
            GameObject cloneGO = Instantiate(gameObject);
            cloneGO.transform.position = m_InitialPosition;
            cloneGO.transform.rotation = m_InitialRotation;
            cloneGO.transform.localScale = m_InitialLocalScale;
            m_RigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            m_CountDown.Decrease();
        }
    }
    IEnumerator Kill()
    {
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
