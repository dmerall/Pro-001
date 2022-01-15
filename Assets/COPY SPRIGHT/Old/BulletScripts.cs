using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BulletScripts : MonoBehaviour
{
    public float plyerBulletSpeed = 10f;
    public float monsterBulletSpeed = 5f;
    private float bulletSpeed;

    public static bool openCpunt = false;
    public static int monsterHP;
    
    
    private void Awake()
    {

        if (this.tag =="Bullet")
        {
            //调用玩家子弹向量
            transform.right = MouseAiming.direction;
            
        }

        if (this.tag =="MonBullet")
        {
            //调用怪物子弹向量
            transform.right = Monster.monsVec;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.tag =="Bullet")
        {
            bulletSpeed = plyerBulletSpeed;

        }

        if (this.tag =="MonBullet")
        {
            bulletSpeed = monsterBulletSpeed;

        }
        
        float step = bulletSpeed * Time.deltaTime;
        //子弹每帧移动

        //子弹移动
        transform.Translate(step,0,0,Space.Self);
        
        //子弹位置坐标
        Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
        
        //判断子弹在屏幕内位置，不在就销毁子弹
        if (sp.x >= Screen.width ||sp.x <=0)
        {
            Destroy(this.gameObject);
        }
        if (sp.y >= Screen.height||sp.y <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }
    
    //检测子弹碰到怪物销毁子弹和怪物物体
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag =="Monster" && this.tag =="Bullet")
        {


                Destroy(other.gameObject);

            Destroy(this.gameObject);
            openCpunt = true;
            
        }
        
        if (other.collider.tag =="Player" && this.tag =="MonBullet")
        {

               Destroy(this.gameObject);
               //Destroy(other.gameObject);

        }
        
        if (other.collider.tag =="Flooring" )
        {

            Destroy(this.gameObject);

        }

        
    }
    
}
