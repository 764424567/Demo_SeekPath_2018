using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_Control : MonoBehaviour
{
    public Slider m_Slider;
    public Image m_Image;
    private float m_RotateTime;
    public Text m_SliderNumTest;
    private string m_ShortString;
    public float m_SliderSpeed = 3;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_Slider.value = m_RotateTime / m_SliderSpeed;
        m_RotateTime += Time.deltaTime;

        int num = (int)(m_Slider.value * 100);
        m_SliderNumTest.text = num.ToString() + "%";
        if (m_Slider.value >= 0.997f)
        {
            m_SliderNumTest.text = "100%";
        }
    }

    public void ImageRotate_Control(float i)
    {
        m_Image.transform.eulerAngles = new Vector3(0, 0, i * 360);
    }
}
