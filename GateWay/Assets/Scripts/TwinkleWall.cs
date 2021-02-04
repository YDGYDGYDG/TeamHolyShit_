﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinkleWall : MonoBehaviour
{
    float timeSpan;  // 경과 시간
    float WallReset; // 벽 초기화
    float A_WallTime = 1.0f;
    float B_WallTime = 1.0f;
    public GameObject Awall_0;
    public GameObject Awall_1;
    public GameObject Awall_2;
    public GameObject Awall_3;
    public GameObject Awall_4;
    public GameObject Awall_5;
    public GameObject Bwall_6;
    public GameObject Bwall_7;
    public GameObject Bwall_8;
    public GameObject Bwall_9;
    public GameObject Bwall_10;
    public GameObject Bwall_11;

    // Start is called before the first frame update
    void Start()
    {
        Awall_0.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_10.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_11.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
    }

    void AWall()
    {
        Awall_0.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_0.gameObject.tag = "Wall";
        Awall_1.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_1.gameObject.tag = "Wall";
        Awall_2.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_2.gameObject.tag = "Wall";
        Awall_3.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_3.gameObject.tag = "Wall";
        Awall_4.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_4.gameObject.tag = "Wall";
        Awall_5.GetComponent<SpriteRenderer>().material.color = Color.white;
        Awall_5.gameObject.tag = "Wall";
        Bwall_6.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_6.gameObject.tag = "Untagged";
        Bwall_7.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_7.gameObject.tag = "Untagged";
        Bwall_8.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_8.gameObject.tag = "Untagged";
        Bwall_9.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_9.gameObject.tag = "Untagged";
        Bwall_10.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_10.gameObject.tag = "Untagged";
        Bwall_11.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Bwall_11.gameObject.tag = "Untagged";
    }
    void BWall()
    {
        Awall_0.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_0.gameObject.tag = "Untagged";
        Awall_1.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_1.gameObject.tag = "Untagged";
        Awall_2.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_2.gameObject.tag = "Untagged";
        Awall_3.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_3.gameObject.tag = "Untagged";
        Awall_4.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_4.gameObject.tag = "Untagged";
        Awall_5.GetComponent<SpriteRenderer>().material.color = new Color(255, 255, 255, 0);
        Awall_5.gameObject.tag = "Untagged";
        Bwall_6.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_6.gameObject.tag = "Wall";
        Bwall_7.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_7.gameObject.tag = "Wall";
        Bwall_8.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_8.gameObject.tag = "Wall";
        Bwall_9.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_9.gameObject.tag = "Wall";
        Bwall_10.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_10.gameObject.tag = "Wall";
        Bwall_11.GetComponent<SpriteRenderer>().material.color = Color.white;
        Bwall_11.gameObject.tag = "Wall";
    }
    // Update is called once per frame
    void Update()
    {
        WallReset = B_WallTime + A_WallTime;

        timeSpan += Time.deltaTime;
        if (timeSpan < A_WallTime)
            AWall();
        if (timeSpan >= B_WallTime)
            BWall();

        if (timeSpan > WallReset)
            timeSpan = 0;
    }
}