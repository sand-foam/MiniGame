using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class Flower3Open : MonoBehaviour, QuestBehavior
    {
        private Animator m_animator;
        private AnimatorStateInfo m_animatorStateInfo;
        private Collider2D m_1collider2D;
        private Collider2D m_2collider2D;
        private Collider2D m_3collider2D;
        public void OnUpdate()
        {
            if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Flower1") && m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                
                m_animator.SetBool("ToInit", true);
                m_animator.SetBool("Flower1", false);

            }
            if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Flower2") && m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                m_animator.SetBool("Flower3", true);
                QuestController.Instance.UnRegisterQuest(gameObject.ToString());
                QuestController.Instance.UnRegisterQuest("Flower2");
                QuestController.Instance.UnRegisterQuest("Flower3");
                m_1collider2D.enabled = false;
                m_2collider2D.enabled = false;
                m_3collider2D.enabled = false;

            }
        }

        // Start is called before the first frame update
        void Start()
        {
            QuestController.Instance.RegisterQuest(gameObject.ToString(), this);
            m_animator = GameObject.Find("Right").GetComponent<Animator>();
            m_1collider2D = GameObject.Find("Flower1").GetComponent<Collider2D>();
            m_2collider2D = GameObject.Find("Flower2").GetComponent<Collider2D>();
            m_3collider2D = GameObject.Find("Flower3").GetComponent<Collider2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}