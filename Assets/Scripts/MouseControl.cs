using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{


private void Update() {

    FollowMouseRotate();
}


private void FollowMouseRotate(){

Vector3 mousePos =Input.mousePosition;
Vector3 gunPosition =Camera.main.WorldToScreenPoint(transform.position);

mousePos = (mousePos - gunPosition).normalized;

float gunangle = Mathf.Atan2(mousePos.y ,mousePos.x)*Mathf.Rad2Deg;

if(Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x){
    transform.rotation =Quaternion.Euler(new Vector3(180f, 0f, -gunangle));
    transform.localScale =new Vector3(-1,1,1);

}else{
    transform.rotation =Quaternion.Euler(new Vector3(0f, 0f, gunangle));
    transform.localScale =new Vector3(-1,1,1);
}


}
}
