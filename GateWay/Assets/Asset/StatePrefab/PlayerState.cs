﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    HookShotScript hookLine;    // 훅 연결용 변수
    public GameObject playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        hookLine = GameObject.Find("player").GetComponent<HookShotScript>();    // 훅샷 스크립트 연결
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Monster")        // 너 몬스터랑 충돌했니??
        {
            this.gameObject.SetActive(false);   // 그럼 뒤지삼
            hookLine.HookOFF();                 // 훅도 지워줘야지??
            Instantiate(playerDeath, transform.position, Quaternion.identity);    // 이펙트도 출력해

            
        }
    }



    

    // Update is called once per frame
    void Update()
    {
        
    }
}