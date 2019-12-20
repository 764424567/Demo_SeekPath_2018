using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Control1 : MonoBehaviour
{
    public GameObject[] m_LineRendererGameObject;
    private bool m_isFrist = true;

    public GameObject[] m_CameraList;
    // Use this for initialization
    void Start()
    {
        m_LineRendererGameObject[0].SetActive(false);
        m_LineRendererGameObject[1].SetActive(false);
        m_CameraList[0].SetActive(false);
        m_CameraList[1].SetActive(true);
        m_CameraList[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonOnClick_LineControl()
    {
        
        if (m_isFrist)
        {
            m_LineRendererGameObject[0].SetActive(true);
            m_LineRendererGameObject[1].SetActive(true);
            m_isFrist = false;
        }
        else
        {
            m_LineRendererGameObject[0].SetActive(false);
            m_LineRendererGameObject[1].SetActive(false);
            m_isFrist = true;
        }
    }
    
    public void Camera_Control()
    {
        m_CameraList[0].SetActive(true);
        m_CameraList[1].SetActive(false);
    }

    public void Camera_Control2()
    {
        m_CameraList[0].SetActive(false);
        m_CameraList[2].SetActive(true);
    }
}
