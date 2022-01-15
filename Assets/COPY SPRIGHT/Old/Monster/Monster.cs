using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;



public  class Monster : MonoBehaviour
{
    public static Monster instance;
    
    //怪物移动速度
    public float moveSpeed =2f;
    
    //怪物是否面向左
    public bool toLeft;
    
    //怪物移动距离
    public float moveDitance = 3f;
    
    //怪物警戒距离
    public float alertRange = 3f;
    
    //怪物瞄准
    public static bool monsterAiming =false;
    //怪物与玩家的向量
     static public  Vector3 monsVec;
    
    //怪物与玩家的距离
    private float diantance;
    
    
    private void Awake()
    {
        instance = this;

    }


    // Update is called once per frame
    void Update()
    {
        MonsterMove();
        AlertRange();

        if (BulletScripts.openCpunt !=false)
        {
            BulletScripts.openCpunt = false;
        }
        
    }

//怪物移动
    void MonsterMove()
    {
        if (diantance >= alertRange)
        {
            monsterAiming = false;       
            float move = moveSpeed * Time.deltaTime;
            transform.Translate(move,0,0);
        }
        else
        {
            monsterAiming = true;
        }


        //移动时面向
        if (transform.position.x >moveDitance && !toLeft)
        {
            toLeft = true;
            transform.localEulerAngles =new Vector3(0,0,180);
        }

        if (transform.position.x < -moveDitance && toLeft)
        {
            toLeft = false;
            transform.localEulerAngles =new Vector3(0,0,0);
        }

    }
    
    //怪物警戒
      void AlertRange()
    {
        
        //查找玩家组件
        GameObject plyerObj = GameObject.Find("Player");
        
        //玩家非空情况下，玩家场景坐标
        if (plyerObj != null)
        {
            Vector3 playerPos = plyerObj.transform.position;

            //怪物场景坐标
            Vector3 monsterPos = transform.position;
            monsterPos.z = 0;

        
            //怪物与玩家的距离
            diantance = (monsterPos - playerPos).magnitude;
            
            //怪物与玩家的向量
            monsVec = (playerPos- monsterPos).normalized;



        }
        
    }

}
