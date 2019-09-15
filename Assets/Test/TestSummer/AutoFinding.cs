using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFinding : MonoBehaviour
{
    public GameObject m_followTarget;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(m_followTarget.transform.position.x, m_followTarget.transform.position.y + 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(m_followTarget.transform.position.x, m_followTarget.transform.position.y + 1.0f, 0.0f);
    }
}
