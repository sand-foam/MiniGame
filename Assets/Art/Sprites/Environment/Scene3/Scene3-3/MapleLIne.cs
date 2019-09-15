using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapleLIne : MonoBehaviour, QuestBehavior
{
    public List<GameObject> obj;
    private Collider2D m_maple;
    private Vector2 m_originPos;//原来位置
    private Vector2 m_offset;//触摸位置与物体中心点的偏移
    private bool m_isSuccess = false;//此处机关是否成功破解
    private int m_n;
    int[] m_time = new int[20];
    private Animator m_animator;//枫树林渐密动画
    private Animator m_Leftanimator;//左边枫叶动画
    private bool m_LeftSuccess = false;//左边枫叶动画是否播完
    // Start is called before the first frame update
    void Start()
    {
        QuestController.Instance.RegisterQuest(gameObject.ToString(), this);
        m_maple =this.GetComponent<Collider2D>();
        m_animator = GameObject.Find("autumn").GetComponent<Animator>();
        Debug.Log(m_originPos);
        m_originPos = transform.position;
        m_Leftanimator = GameObject.Find("MapleLeft").GetComponent<Animator>();
        m_n = obj.Count;
        for (int i = 0; i < m_n; i++)
        {
            m_time[i] = 0;
        }
        this.enabled = false;
    }

    // Update is called once per frame

    void Update()

    {
        ////Android端
        //if (Input.touchCount == 1)
        //{

        //    Touch touch = Input.touches[0];
        //    Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);


        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        m_offset = new Vector2(transform.position.x, transform.position.y) - touchPos;
        //    }
        //    if (touch.phase == TouchPhase.Moved)
        //    {
        //        Vector2 currPos = touchPos + m_offset;
        //        
        //        transform.position = new Vector3(currPos.x, currPos.y, transform.position.z);
        //        
        //    }
        //    if (touch.phase == TouchPhase.Ended)
        //    {
        //        if (m_time[0] == 1 && m_time[1] == 1 && m_time[2] == 1 && m_time[3] == 1 && m_time[4] == 1 && m_time[5] == 1 && m_time[6] == 1 && m_time[7] == 1 && m_time[8] == 1 && m_time[9] == 0 && m_time[10] == 0)
        //        {
        //          m_isSuccess = true;

        //         }
        //        if (m_isSuccess)
        //        {
        //                        Debug.Log("机关成功");
        //                        QuestController.Instance.UnRegisterQuest(gameObject.ToString());
        //                        m_animator.enabled = true;//枫树林渐密
        //                        Destroy(gameObject);
        //                        this.enabled = false;
        //        }
        //        else
        //        {
        //            m_time[0] = 0;
        //            m_time[1] = 0;
        //            m_time[2] = 0;
        //            m_time[3] = 0;
        //            m_time[4] = 0;
        //            m_time[5] = 0;
        //            m_time[6] = 0;
        //            m_time[7] = 0;
        //            m_time[8] = 0;
        //            m_time[9] = 0;
        //            m_time[10] = 0;
        //            Debug.Log("回去");
        //            //瞬时回到原来位置
        //            transform.position = new Vector3(m_originPos.x, m_originPos.y, transform.position.z);
        //            this.enabled = false;
        //            //过渡回到原来位置
        //        }
        //    }
        //}
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_offset = new Vector2(transform.position.x, transform.position.y) - touchPos;
        }
    }

    private void OnMouseDrag()
    {
        //Debug.Log("拖拽物体");
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 currPos = touchPos + m_offset;
            transform.position = new Vector3(currPos.x, currPos.y, transform.position.z);
        }
    }

    /// <summary>
    /// 在此处做机关触发判断
    /// </summary>
    private void OnMouseUp()
    {
        //if (Input.GetMouseButton(0))
        //{
        //先做机关破解成功判断
        
        //是否大致按路线
        if (m_time[0] ==1&&m_time[1] == 1 && m_time[2] == 1 &&m_time[3] == 1 &&m_time[4] == 1 &&m_time[5] == 1 &&m_time[6] == 1 &&m_time[7] == 1 &&m_time[8] == 1 && m_time[9] == 0 && m_time[10] == 0)
        {
            m_isSuccess = true;
            //Debug.Log(m_time[0]);
            //Debug.Log(m_time[1]);
            //Debug.Log(m_time[2]);
            //Debug.Log(m_time[3]);
            //Debug.Log(m_time[4]);
            //Debug.Log(m_time[5]);
            //Debug.Log(m_time[6]);
            //Debug.Log(m_time[7]);
            //Debug.Log(m_time[8]);
        }


        if (m_isSuccess)
        {
            Debug.Log("机关成功");
            QuestController.Instance.UnRegisterQuest(gameObject.ToString());
            m_animator.enabled = true;//枫树林渐密
            Destroy(gameObject);
            this.enabled = false;
        }
        else
        {

            m_time[0] = 0;
            m_time[1] = 0;
            m_time[2] = 0;
            m_time[3] = 0;
            m_time[4] = 0;
            m_time[5] = 0;
            m_time[6] = 0;
            m_time[7] = 0;
            m_time[8] = 0;
            m_time[9] = 0;
            m_time[10] = 0;
            //瞬时回到原来位置
            transform.position = new Vector3(m_originPos.x, m_originPos.y, transform.position.z);
            Debug.Log("???");
            this.enabled = false;
            //过渡回到原来位置
        }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //可以采取距离判断或者物体碰撞的方式判断机关是否已经破解。此处采用物体碰撞
        if (collision.gameObject.Equals(obj[1]))
        {
            m_time[1]+= 1;
            Debug.Log("碰到1了");
            Debug.Log(m_time[1]);

        }
        if (collision.gameObject.Equals(obj[2])&& m_time[1]==1)
        {
            m_time[2]+= 1;
            Debug.Log("碰到2了");

        }
        if (collision.gameObject.Equals(obj[3]) && m_time[2] == 1)
        {
            m_time[3]+= 1;
            Debug.Log("碰到3了");

        }
        if (collision.gameObject.Equals(obj[4]) && m_time[3] == 1)
        {
            m_time[4]+= 1;
            Debug.Log("碰到4了");

        }
        if (collision.gameObject.Equals(obj[5]) && m_time[4] == 1)
        {
            m_time[5]+= 1;
            Debug.Log("碰到5了");

        }
        if (collision.gameObject.Equals(obj[6]) && m_time[5] == 1)
        {
            m_time[6] += 1;
            Debug.Log("碰到6了");

        }
        if (collision.gameObject.Equals(obj[7]) && m_time[6] == 1)
        {
            m_time[7] += 1;
            Debug.Log("碰到7了");

        }
        if (collision.gameObject.Equals(obj[8]) && m_time[7] == 1)
        {
            m_time[8] += 1;
            Debug.Log("碰到8了");

        }
        if (collision.gameObject.Equals(obj[9]))
        {
            m_time[8] += 1;
            Debug.Log("碰到9了");

        }
        if (collision.gameObject.Equals(obj[10]))
        {
            m_time[8] += 1;
            Debug.Log("碰到10了");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.Equals(obj[0]))
        {
            m_time[0] += 1;
            Debug.Log("离开0了");
        }
    }

    public void OnUpdate()
    {

        if (m_Leftanimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            m_LeftSuccess = true;
            Debug.Log("????????????");
        }

        if (m_LeftSuccess)
        {
            this.enabled = true;
        }
    }
}
