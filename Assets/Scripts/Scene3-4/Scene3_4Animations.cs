using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3_4Animations : MonoBehaviour
{
    [Tooltip("3-4场景动画事件")]
    private GameObject m_snowScene;
    private GameObject m_girl;
    private GameObject m_room;
    private GameObject m_cryingMan;
    private GameObject m_boy;
    // Start is called before the first frame update
    void Start()
    {
        m_snowScene = GameObject.Find("SnowScene");
        m_girl = GameObject.FindGameObjectWithTag("Girl");
        m_room = GameObject.Find("IndoorRoom");
        m_cryingMan = GameObject.Find("CryingMan");
        m_boy = GameObject.FindGameObjectWithTag("Boy");
    }

    void SnowFallingAnimatorFire()
    {
        m_snowScene.GetComponent<Animator>().enabled = true;
    }

    void GirlPlayingSnowFire()
    {
        m_girl.GetComponent<Animator>().SetTrigger("GirlPlayingSnowTrigger");
    }

    void IndoorRoomHideFire()
    {
        m_room.GetComponent<Animator>().enabled = true;
    }

    void CryingManAppear()
    {
        m_cryingMan.GetComponent<Animator>().enabled = true;
    }

    void BoyPlayingSnowFire()
    {
        m_boy.GetComponent<Animator>().SetTrigger("BoyPlayingSnowTrigger");
    }
}
