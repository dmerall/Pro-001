using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
public float fireSpeed;


private void Update() {

    transform.Translate(Vector2.right *fireSpeed *Time.deltaTime,Space.Self);
    
}


private void OnTriggerEnter2D(Collider2D other) {
    Destroy(gameObject,5f);
    
}
}
