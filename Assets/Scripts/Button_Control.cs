using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Control : MonoBehaviour
{
    public LineRenderer m_LineRenderer;
    // Use this for initialization
    void Start()
    {
        m_LineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonOnClick_LineControl()
    {
        m_LineRenderer.enabled = true;
    }
}
