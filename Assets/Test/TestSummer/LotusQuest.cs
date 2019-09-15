using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotusQuest : MonoBehaviour, QuestBehavior
{
    private Camera m_mainCam;

    // Start is called before the first frame update
    void Start()
    {
        m_mainCam = Camera.main;
        QuestController.Instance.RegisterQuest(gameObject.ToString(), this);
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = m_mainCam.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector3(mousePos.x, mousePos.y, 0.0f);
        }
        else
            this.enabled = false;
    }

    public void OnUpdate()
    {
        this.enabled = true;
    }
}
