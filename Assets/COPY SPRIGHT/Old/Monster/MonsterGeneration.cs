using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGeneration : MonoBehaviour
{
    public GameObject[] monsterPoint;
    public GameObject[] monsterPre;
    static public GameObject bulletHe;
    private GameObject monsterHe;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        bulletHe =new GameObject();
        bulletHe.name = "BulletBox";
        
        monsterHe =new GameObject();
        monsterHe.name = "MonstereClub";
        
        
        
        for (int i = 0; i < monsterPoint.Length; i++)
        {

            Vector3 monsterPos = monsterPoint[i].transform.position;

            for (int k = 0; k < monsterPre.Length; k++)
            {
                if (k < 1)
                {
                    int indexIn = Random.Range(0, monsterPre.Length);
                    GameObject monsterIn = Instantiate(monsterPre[indexIn]);
                
                    monsterIn.transform.position = monsterPos;
                    monsterIn.transform.parent = monsterHe.transform;
                }
                
            }

        }
        
    }
    
}
