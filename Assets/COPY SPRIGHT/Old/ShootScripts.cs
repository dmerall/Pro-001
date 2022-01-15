using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ShootScripts : MonoBehaviour
{
    //子弹预制体
    public GameObject bulletPre;
    
    //子弹发射点坐标
    public Transform qiangKou;
    


    //玩家射击间隔
    private float interval = 0.3f;
    //怪物射击间隔
    private float intervalMon = 1f;
    
    //射击计时
    private float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //初始帧率
        Application.targetFrameRate = 60;




    }

    // Update is called once per frame
    void Update()
    {
        //计时
        count += Time.deltaTime;
        if (this.tag == "Player")
        {
            //玩家左键射击
            if (Input.GetMouseButtonDown(0) && count >= interval)
            {
                count = 0;
                Fire();
            }
        }

        if (this.tag == "Monster" && count >= intervalMon)
        {
            if (Monster.monsterAiming != false)
            {
                count = 0;
                Fire();
            }

        }
    }

    //子弹实例化
    void Fire()
    {
        GameObject bullet = Instantiate(bulletPre);
        bullet.transform.position = qiangKou.position;
        bullet.transform.parent = MonsterGeneration.bulletHe.transform;
    }
}
