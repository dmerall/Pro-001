using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    //玩家移动速度
    public float moveSpeed =1.5f;
    
    //玩家跳跃速度
    public float jumpSpeed = 5f;
    
    //是否跳跃中
    public bool isJump ;
    
    //玩家2D刚体
    private Rigidbody2D rig;
    
    
    
    private void Start()
    {
        //初始化玩家刚体
        rig = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()
    {
        //玩家每帧移动
        float move = moveSpeed * Time.deltaTime;
        
        //按键控制
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-move,0,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(move,0,0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            rig.velocity = Vector3.up * jumpSpeed;
            isJump = true;
        }

        
    }
    
    //检测跳跃状态
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.tag =="Flooring")
        {
            isJump = false;
        }
    }
}
