﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_LaserProjector : MonoBehaviour
{
    Vector2 laserDir;
    Vector2 laserPos;
    public LineRenderer line;
    int layerMask_ignore;
    RaycastHit2D hit;

    public GameObject [] triggerObjects;

    void Awake()
    {
        layerMask_ignore = 1 << LayerMask.NameToLayer("LaserProjector");
        layerMask_ignore = ~layerMask_ignore;
        line.positionCount = 1;
        line.endWidth = line.startWidth = 0.2f;
        line.SetPosition(0, transform.position);
        line.useWorldSpace = true;
    }

    void Update()
    {
        line.SetPosition(0, transform.position);
        line.positionCount = 1;
        laserDir = transform.right;
        laserPos = transform.position;

        line.positionCount++;
        hit = Physics2D.Raycast(laserPos, laserDir, Mathf.Infinity, layerMask_ignore);
        if (hit)
        {
            line.SetPosition(line.positionCount - 1, hit.point);
            // 센서에 레이저가 닿으면
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("LaserCensor"))
            {
                for (int i = 0; i < triggerObjects.Length; i++) 
                {
                    triggerObjects[i].GetComponent<Trigger_Door>().TriggerOn();
                }
            }

            while (hit.collider.gameObject.layer == LayerMask.NameToLayer("Mirror") && line.positionCount < 50)
            {
                laserPos = hit.point - (laserDir.normalized * 0.0001f);
                laserDir = Vector2.Reflect(laserDir, hit.normal);
                hit = Physics2D.Raycast(laserPos, laserDir, Mathf.Infinity, layerMask_ignore);
                if (hit)
                {

                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, hit.point);
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("LaserCensor"))
                    {
                        for (int i = 0; i < triggerObjects.Length; i++)
                        {
                            triggerObjects[i].GetComponent<Trigger_Door>().TriggerOn();
                        }
                    }
                }
                else break;
            }

        }
        else line.SetPosition(line.positionCount - 1, transform.position);

        // 기계행성은 무조건 벽으로 둘러싸서 레이저가 어딘가에 부딪히게 하자
        //// 걸리는 게 없으면 그냥 멀리멀리 그려라
        //else
        //{

        //}
    }


}
