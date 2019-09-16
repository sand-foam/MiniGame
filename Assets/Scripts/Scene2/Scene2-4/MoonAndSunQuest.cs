using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class MoonAndSunQuest : MonoBehaviour, QuestBehavior
    {
        //业务变量
        /// <summary>
        /// 机关音效
        /// </summary>
        public AudioClip m_moonAndSunAudioClip;
        /// <summary>
        /// 缩放业务变量
        /// </summary>
        private Vector2 m_oldVector;
        private Quaternion m_originRotation;
        private GameObject m_mainCam;
        private GameObject m_flyingMagpie;
        public GameObject m_other;
        private GameObject m_moonAndSun;
        private Vector3 m_center;
        //日月跟随 -- 改为不跟（未定）

        private float m_angleCounter;
        /// <summary>
        /// 注册机关
        /// 初始化比例系数
        /// </summary>
        void Start()
        {
            m_moonAndSun = GameObject.Find("MoonAndSun");
            QuestController.Instance.RegisterQuest(gameObject.ToString(), this);
            m_originRotation = m_moonAndSun.transform.localRotation;
            m_mainCam = GameObject.FindGameObjectWithTag("MainCamera");
            m_flyingMagpie = GameObject.Find("FlyingMagpie");
            m_angleCounter = 0f;
            m_center = m_moonAndSun.transform.position;
            this.enabled = false;
        }

        // Android enabled
        void Update()
        {
            // Android --stable
            //if (Input.touchCount > 0)
            //{
            //    Touch touch1 = Input.GetTouch(0);
            //    Vector2 touchPos1;
            //    touchPos1 = Camera.main.ScreenToWorldPoint(touch1.position);

            //    if (touch1.phase == TouchPhase.Began)
            //    {
            //        Debug.Log("Touch1 began");
            //        m_oldVector = touchPos1 - (Vector2)m_center;
            //        return;
            //    }
            //    if (touch1.phase == TouchPhase.Moved)
            //    {
            //        Debug.Log("Moving");
            //        Vector2 newVector = touch1.position - (Vector2)m_center;
            //        Vector3 preDirectionVec3 = new Vector3(m_oldVector.x, m_oldVector.y, transform.position.z);
            //        Vector3 currDirectionVec3 = new Vector3(newVector.x, newVector.y, transform.position.z);

            //        float angle = Vector3.Angle(preDirectionVec3, currDirectionVec3);
            //        Vector3 normal = Vector3.Cross(preDirectionVec3, currDirectionVec3);
            //        angle *= Mathf.Sign(Vector3.Dot(normal, transform.forward));
            //        m_angleCounter += angle;
            //        m_moonAndSun.transform.Rotate(new Vector3(0, 0, angle));
            //        m_oldVector = newVector;

            //        if (Mathf.Abs(m_angleCounter) >= 180f)
            //        {
            //            m_moonAndSun.transform.localRotation = new Quaternion(0, 0, 180f, 0);
            //            gameObject.GetComponent<Collider2D>().enabled = false;
            //            AudioController.Instance.PushClip(m_moonAndSunAudioClip);
            //            m_mainCam.GetComponent<CameraController>().enabled = false;
            //            m_mainCam.GetComponent<CameraNaturalTransition>().NaturalTransition1();
            //            m_flyingMagpie.GetComponent<Animator>().enabled = true;
            //            QuestController.Instance.UnRegisterQuest(gameObject.ToString());
            //            QuestController.Instance.UnRegisterQuest(m_other.ToString());
            //            this.enabled = false;
            //        }
            //    }
            //    if (touch1.phase == TouchPhase.Ended)
            //    {
            //        m_other.layer = LayerMask.NameToLayer("Quest");
            //        if (Mathf.Abs(m_angleCounter) < 180f)
            //            SlidBackOriPos();

            //    }
            //}

            // PC/Android -- one handed
            if (Input.GetMouseButton(0))
            {
                Vector2 newVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_center;
                Vector3 preDirectionVec3 = new Vector3(m_oldVector.x, m_oldVector.y, transform.position.z);
                Vector3 currDirectionVec3 = new Vector3(newVector.x, newVector.y, transform.position.z);

                float angle = Vector3.Angle(preDirectionVec3, currDirectionVec3);
                Vector3 normal = Vector3.Cross(preDirectionVec3, currDirectionVec3);
                angle *= Mathf.Sign(Vector3.Dot(normal, transform.forward));
                m_angleCounter += angle;
                m_moonAndSun.transform.Rotate(new Vector3(0, 0, angle));
                m_oldVector = newVector;

                if (Mathf.Abs(m_angleCounter) >= 180f)
                {
                    m_moonAndSun.transform.localRotation = new Quaternion(0, 0, 180f, 0);
                    gameObject.GetComponent<Collider2D>().enabled = false;
                    AudioController.Instance.PushClip(m_moonAndSunAudioClip);
                    m_mainCam.GetComponent<CameraController>().enabled = false;
                    m_mainCam.GetComponent<CameraNaturalTransition>().NaturalTransition1();
                    m_flyingMagpie.GetComponent<Animator>().enabled = true;
                    QuestController.Instance.UnRegisterQuest(gameObject.ToString());
                    QuestController.Instance.UnRegisterQuest(m_other.ToString());
                    this.enabled = false;
                }
            }
            if (!Input.GetMouseButton(0))
            {
                m_other.layer = LayerMask.NameToLayer("Quest");
                if (Mathf.Abs(m_angleCounter) < 180f)
                    SlidBackOriPos();
                else
                {
                    m_moonAndSun.transform.localRotation = new Quaternion(0, 0, 180f, 0);
                    gameObject.GetComponent<Collider2D>().enabled = false;
                    AudioController.Instance.PushClip(m_moonAndSunAudioClip);
                    m_mainCam.GetComponent<CameraController>().enabled = false;
                    m_mainCam.GetComponent<CameraNaturalTransition>().NaturalTransition1();
                    m_flyingMagpie.GetComponent<Animator>().enabled = true;
                    QuestController.Instance.UnRegisterQuest(gameObject.ToString());
                    QuestController.Instance.UnRegisterQuest(m_other.ToString());
                    this.enabled = false;
                }
            }
        }
       
        public void OnUpdate()
        {
            // Android -- stable
            //Debug.Log("Android");
            //this.enabled = true;
            //m_other.layer = LayerMask.NameToLayer("Ignore Mirror");            
            //if (Input.touchCount > 0)
            //{
            //    Touch touch1 = Input.GetTouch(0);
            //    Vector2 touchPos1;
            //    touchPos1 = Camera.main.ScreenToWorldPoint(touch1.position);

            //    m_oldVector = touchPos1 - (Vector2)m_center;
            //}

            // PC/Android -- one handed
            this.enabled = true;
            m_other.layer = LayerMask.NameToLayer("Ignore Mirror");
            m_oldVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_center;

            // PC-- Directly controlled here
            //Debug.Log("PC");
            //this.transform.localRotation = new Quaternion(0, 0, 180f, 0);
            //m_mainCam.GetComponent<CameraController>().enabled = false;
            //m_mainCam.GetComponent<CameraNaturalTransition>().NaturalTransition1();
            //m_flyingMagpie.GetComponent<Animator>().enabled = true;
            //gameObject.GetComponent<Collider2D>().enabled = false;
            //AudioController.Instance.PushClip(m_moonAndSunAudioClip);
            //QuestController.Instance.UnRegisterQuest(gameObject.ToString());
        }

        private void SlidBackOriPos()
        {
            m_moonAndSun.transform.localRotation = m_originRotation;
            m_angleCounter = 0f;
            this.enabled = false;
        }
    }
}

