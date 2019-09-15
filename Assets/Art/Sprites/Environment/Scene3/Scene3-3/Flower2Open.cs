using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class Flower2Open : MonoBehaviour, QuestBehavior
    {
        private Animator m_animator;
        private AnimatorStateInfo m_animatorStateInfo;

        public void OnUpdate()
        {
            if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Flower1")&& m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime>1.0f)
            {
                m_animator.SetBool("Flower2", true);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            QuestController.Instance.RegisterQuest(gameObject.ToString(), this);
            m_animator = GameObject.Find("Right").GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

