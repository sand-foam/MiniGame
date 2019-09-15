using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//用于判断枫树林茂密动画是否播完 成功则开花
public class AutumnScript : MonoBehaviour
{
    private Animator m_animator;
    private Animator m_Leftanimator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = GameObject.Find("autumn").GetComponent<Animator>();//枫树林渐密动画
        m_Leftanimator = GetComponent<Animator>();//左开花动画
    }

    // Update is called once per frame
    void Update()
    {
        if (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)//渐密动画播完
        {
            m_Leftanimator.enabled = true;
            this.enabled = false;
        }
    }
}