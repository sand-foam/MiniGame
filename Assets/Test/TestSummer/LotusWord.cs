using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LotusWord : MonoBehaviour
{
    public GameObject m_word;
    private Text m_text;
    private bool m_wordShown = false;
    private bool m_startShow = false;
    private bool m_startFade = false;
    private float m_stay = 0.0f;

    void Start()
    {
        m_text = m_word.GetComponent<Text>();
    }

    void Update()
    {
        if (m_wordShown)
        {
            Color wordColor = m_text.color;
            if (wordColor.a <= 0.0f)            
                m_startShow = true;            
            m_wordShown = false;
        }

        if (m_startShow)
        {
            Color wordColor = m_text.color;
            if (wordColor.a < 1.0f)
                m_text.color = new Color(wordColor.r, wordColor.g, wordColor.b, wordColor.a + 0.02f);
            else
            {
                m_stay += Time.deltaTime;
                if (m_stay >= 2.0f)
                {
                    m_stay = 0.0f;
                    m_startShow = false;
                    m_startFade = true;
                }

            }
        }

        if (m_startFade)
        {
            Color wordColor = m_text.color;
            if (wordColor.a > 0.0f)
                m_text.color = new Color(wordColor.r, wordColor.g, wordColor.b, wordColor.a - 0.02f);
            else
                m_startFade = false;
        }
    }

    void OnMouseDown()
    {
        m_wordShown = true;
    }
}
