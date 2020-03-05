using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate=2.5f;
    private float xPosition=11.0f;
    Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawn",0,spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemySpawn(){
        int randomSide = Random.Range(0,2);
        if(randomSide == 0){
            spawnPosition = new Vector2(-xPosition,transform.position.y);
        }else{
            spawnPosition = new Vector2(xPosition,transform.position.y);
        }
        Instantiate(enemy,spawnPosition,Quaternion.identity);

    }
}
