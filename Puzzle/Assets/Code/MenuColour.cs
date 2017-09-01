using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuColour : MonoBehaviour {
    
    public float m_Speed = 0.1f;
    private Renderer rend;
    private Material m_Material;
    private Color m_Color;
    private float h = 0;
    private Vector4 m_HSVA;

    float m_Time;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Custom/HSVRangeShader");
        m_HSVA = new Vector4(h, rend.material.GetVector("_HSVAAdjust").y, rend.material.GetVector("_HSVAAdjust").z, 0f );
    }

    void FixedUpdate()
    {
        h += Mathf.Lerp(0, 1, Time.fixedDeltaTime * m_Speed);
        if (h >= 1)
            h = 0;
        m_HSVA.x = h;
        
        rend.material.SetVector("_HSVAAdjust", m_HSVA);
    }



}
