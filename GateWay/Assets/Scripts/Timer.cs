﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    [SerializeField]
    private Text timeText;

    private BoxCollider2D boxCollider; // 충돌 처리해주기 위한 컴포넌트


    private float secCount = 0;
    private int minCount = 0;
    public static int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        timeText.enabled = false; // 시작할때 타이머 텍스트 비활성화
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (timeText.enabled)
        {
            return;
        }

        Hour();
    }

    // 콜라이더 안에 뭔가 들어옴
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Savepoint")
        {
            timeText.enabled = true;
        }
    }


    // 콜라이더 안에 뭔가 나감
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Savepoint")
        {
            // 시간 초기화
            Init();
            timeText.enabled = false;
        }
    }

    private void Init()
    {
        secCount = 0;
        minCount = 0;
    }

    void Hour()
    {
        secCount += Time.deltaTime;
        timeText.text = string.Format("{0:00}:{1:00}", minCount, (int)secCount);

        if ((int)secCount > 59) // 60초가 되면 분의 숫자가 올라감
        {
            secCount = 0;
            minCount++;
        }
    }
}