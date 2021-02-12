﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonsterDU : MonoBehaviour
{
    public int monsterSpeed = 100;




    // Start is called before the first frame update
    void Start()
    {
        
    }
    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     Destroy(gameObject);
    // }
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2Int(0, -monsterSpeed));
        if(gameObject.transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
    }
}
