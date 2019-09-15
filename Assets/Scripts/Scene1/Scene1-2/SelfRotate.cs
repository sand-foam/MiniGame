using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    private WaterWaveEffect m_setWave;
    private ParticleSystem m_waterL, m_waterR, m_waterM;
    private Camera m_mainCam;
    private float m_wheelRightMax; // x-axis
    private Vector3 m_wheelDown;
    private float m_time;
    private bool m_stop;

    void Start()
    {
        m_setWave = GameObject.Find("Additional Camera").GetComponent<WaterWaveEffect>();
        m_waterL = GameObject.Find("Water_Left").GetComponent<ParticleSystem>();
        m_waterR = GameObject.Find("Water_Right").GetComponent<ParticleSystem>();
        m_waterM = GameObject.Find("Water_Mid").GetComponent<ParticleSystem>();
        m_mainCam = Camera.main;
        Bounds tmp = GameObject.Find("wheel").GetComponent<Collider2D>().bounds;
        m_wheelRightMax = tmp.center.x + tmp.extents.x;
        m_wheelDown = new Vector3(tmp.center.x, tmp.center.y - tmp.extents.y, 0f);
        m_time = 0f;
        m_stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        float orthoHorizontal = m_mainCam.aspect * m_mainCam.orthographicSize;
        if (m_mainCam.transform.position.x - m_wheelRightMax > orthoHorizontal)
        {
            Debug.Log("Self-rotate Stop");
            StopSelfRotate();
        }
        else if (m_stop)
        {
            Restart();
        }

        if (!m_stop)
        {           
            this.transform.Rotate(new Vector3(0, 0, Time.deltaTime * -10));
            if (m_time == 0f)
            {
                Vector4 wavePos;
                Vector3 wheelPos = Camera.main.WorldToScreenPoint(m_wheelDown);
                wavePos = new Vector4(wheelPos.x / Screen.width, wheelPos.y / Screen.height, 0.0f, 0.0f);
                m_setWave.SetWave(wavePos);
            }
            m_time += Time.deltaTime;
            if (m_time > 3.0f)
                m_time = 0f;
        }
    }

    public void StopSelfRotate()
    {
        m_stop = true;
        m_waterL.Stop();
        m_waterR.Stop();
        m_waterM.Stop();
    }

    public void Restart()
    {
        m_stop = false;
        m_waterL.Play();
        m_waterM.Play();
        m_waterR.Play();
    }
}
