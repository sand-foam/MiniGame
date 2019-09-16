using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafHint : MonoBehaviour
{
    private WaterWaveEffect m_setWave;
    private bool m_startHint;
    private Vector3 m_leafDown;
    private Camera m_mainCam;
    private float m_counter;

    // Start is called before the first frame update
    void Start()
    {
        m_setWave = GameObject.Find("Additional Camera").GetComponent<WaterWaveEffect>();
        m_startHint = false;        
        m_mainCam = Camera.main;
        m_counter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_startHint)
        {
            if (m_counter == 0f)
            {
                Vector4 wavePos;
                Vector3 screenPos = m_mainCam.WorldToScreenPoint(m_leafDown);
                wavePos = new Vector4(screenPos.x / Screen.width, screenPos.y / Screen.height, 0.0f, 0.0f);
                m_setWave.SetWave(wavePos);
            }
            m_counter += Time.deltaTime;
            if (m_counter >= 1.5f)
                m_counter = 0f;
        }
    }

    public void StartHint()
    {
        m_startHint = true;
        Bounds tmp = GameObject.Find("Leaf").GetComponent<Collider2D>().bounds;
        m_leafDown = new Vector3(tmp.center.x, tmp.center.y - tmp.extents.y, 0.0f);
    }

    public void StopHint()
    {
        m_startHint = false;
    }
}
