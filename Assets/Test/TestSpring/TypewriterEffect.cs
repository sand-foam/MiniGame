﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class TypewriterEffect : MonoBehaviour
{

    public float charsPerSecond = 0.2f;//打字时间间隔
    public string words;//保存需要显示的文字
    private Text riddle;

    private bool isActive = false;
    private float timer;//计时器

    private int currentPos = 0;//当前打字位置

    // Use this for initialization
    void Start()
    {
        timer = 0;
        isActive = true;
        charsPerSecond = Mathf.Max(0.2f, charsPerSecond);
        riddle = GetComponent<Text>();
        words = riddle.text;
        transform.position = new Vector3(0,0,0);
        //myText.text = "";//获取Text的文本信息，保存到words中，然后动态更新文本显示内容，实现打字机的效果
    }

    // Update is called once per frame
    void Update()
    {
        OnStartWriter();
        //Debug.Log (isActive);
    }

    public void Show()
    {
        isActive = true;
    }
    /// <summary>
    /// 执行打字任务
    /// </summary>
    void OnStartWriter()
    {

        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//判断计时器时间是否到达
                timer = 0;
                currentPos++;
                riddle.text = words.Substring(0, currentPos);//刷新文本显示内容

                if (currentPos >= words.Length)
                {
                    OnFinish();
                }
            }

        }
    }
    /// <summary>
    /// 结束打字，初始化数据
    /// </summary>
    void OnFinish()
    {
        isActive = false;
        timer = 0;
        currentPos = 0;
        riddle.text = words;
    }




}
