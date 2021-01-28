﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour
{
    GameObject player;

    HookShotScript hookShot;
    DistanceJoint2D joint2D;

    GameObject attackHook;      // 충돌 사운드 재생용(형준)

    GameObject hookSE;          // 훅 SE 정지용(형준)




    void Start()
    {
        player = GameObject.Find("player");
        hookShot = player.GetComponent<HookShotScript>();
        joint2D = GetComponent<DistanceJoint2D>();

         attackHook = GameObject.Find("HookSE");     // 훅 사운드 컴포넌트 연결(형준)
         hookSE = GameObject.Find("Hook");         // 훅 컴포넌트 연결(형준)

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hookShot.isLineMax)
        {
            // 훅이 벽에 닿으면
            if (collision.CompareTag("Wall"))
            {
                joint2D.enabled = true;
                hookShot.isAttach = true;
                hookShot.isAttachWall = true;

                hookShot.ropeLength = (player.transform.position - transform.position).magnitude;

                  hookSE.GetComponent<AudioSource>().Stop();          // 로프 사운드 정지(형준)
                  attackHook.GetComponent<AudioSource>().Play();      // 충돌 사운드 재생(형준)
            }

            // 훅이 SteelWall에 닿으면
            else if (collision.CompareTag("SteelWall"))
            {
                hookShot.HookOFF();
            }

            // 훅이 오브젝트에 닿으면
            else if (collision.CompareTag("Object"))
            {
                joint2D.enabled = true;
                hookShot.isAttach = true;
                hookShot.isAttachObject = true;
                hookShot.hookedObject = collision.gameObject;
                if (collision.GetComponent<BoxCollider2D>())
                    hookShot.hookedObjectSize = collision.GetComponent<BoxCollider2D>().bounds.extents.magnitude / 2.0f;
                else if (collision.GetComponent<PolygonCollider2D>())
                    hookShot.hookedObjectSize = collision.GetComponent<PolygonCollider2D>().bounds.extents.magnitude / 2.0f;

                 hookSE.GetComponent<AudioSource>().Stop();          // 로프 사운드 정지(형준)
                 attackHook.GetComponent<AudioSource>().Play();      // 충돌 사운드 재생(형준)
            }

            // 훅이 마개에 닿으면
            else if (collision.CompareTag("Cap"))
            {
                // 줄 거두기
                hookShot.HookOFF();
                // 해당 마개 제거
                collision.gameObject.SetActive(false);
                hookSE.GetComponent<AudioSource>().Stop();          // 로프 사운드 정지(형준)
                attackHook.GetComponent<AudioSource>().Play();      // 충돌 사운드 재생(형준)

                // hookSE.GetComponent<AudioSource>().Stop();         -->      로프 사운드 정지(형준)
                // attackHook.GetComponent<AudioSource>().Play();     -->      충돌 사운드 재생(형준)
            }

            // ~ 물체에 닿으면
            //else if (collision.CompareTag(""))
            //{
            //    // 줄 거두기
            //    hookShot.HookOFF();
            // }
        }
    }

}
