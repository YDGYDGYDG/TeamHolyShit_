﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPortraitMonster : MonoBehaviour
{
    public float monsterSpeed = 1.0f;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Water")
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(monsterSpeed,0,0);
    }
}
