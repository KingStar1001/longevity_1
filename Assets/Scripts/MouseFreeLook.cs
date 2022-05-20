using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MouseFreeLook : MonoBehaviour
{
    [SerializeField]
    private MouseLook m_MouseLook;
    public Camera m_Camera;

    public Transform m_Follow;

    void Start()
    {
			m_MouseLook.Init(transform , m_Camera.transform);        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_MouseLook.UpdateCursorLock();        
    }
    void Update(){
        RotateView();
        m_Camera.transform.position = m_Follow.transform.position;
    }
    private void RotateView()
    {
        m_MouseLook.LookRotation (transform, m_Camera.transform);
    }
}
