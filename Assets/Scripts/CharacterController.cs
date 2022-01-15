using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class CharacterController : MonoBehaviour
{


public float palyerMoveSpeed;

public float playerJumpForce;

public float checkRadius;


//设置一个跳跃监测层---角色与地面的检测
public LayerMask WhatIsGround;

//角色默认是否着地--true
public bool isGround;


private Collider2D playerColi;

private Rigidbody2D playerRig;

private Transform weaponPoint;
private Transform cheackPoint;





public GameObject bullet;
public Transform startPoint;



private void Awake() {
    playerColi =GetComponent<Collider2D>();
    playerRig = GetComponent<Rigidbody2D>();


    GameObject go = GameObject.Find("Player");
    cheackPoint =go.transform.Find("CheckPoint");

}


void Update() {

    isGround = Physics2D.OverlapCircle(cheackPoint.position, checkRadius, WhatIsGround);


    if(Input.GetAxisRaw("Horizontal") > 0){
        playerRig.velocity = new Vector2(palyerMoveSpeed,playerRig.velocity.y);

    }

    else if(Input.GetAxisRaw("Horizontal") < 0){
        playerRig.velocity = new Vector2(-palyerMoveSpeed,playerRig.velocity.y);

    }
    else{
        playerRig.velocity =new Vector2(0,playerRig.velocity.y);
    }

    if(Input.GetButtonDown("Jump") && isGround){ 
    playerRig.velocity =new Vector2(playerRig.velocity.x,playerJumpForce);
    }



Vector3 gunPos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
if(gunPos.x < transform.position.x){
    transform.eulerAngles =new Vector3(transform.rotation.x ,0f, transform.rotation.z);

}else{
    transform.eulerAngles =new Vector3(transform.rotation.x ,180f, transform.rotation.z);
}


if(Input.GetMouseButtonDown(0)){
shooting();
}

}

void shooting(){
    GameObject shoot =Instantiate(bullet,startPoint.transform.position ,startPoint.transform.rotation);
    Destroy(shoot,5f);
}

}

