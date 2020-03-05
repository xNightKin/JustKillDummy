using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLootBox : MonoBehaviour
{
    public GameObject lootBox;
    public float spawnRate=0.5f;
    private float xBoundary = 5f;
    private float yPosition = 6.7f;
    Vector2 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LootBoxSpawn",spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LootBoxSpawn(){
        float randomTime = Random.Range(6,15);
        float xRandPosition = Random.Range(-xBoundary,xBoundary);
            spawnPosition = new Vector2(xRandPosition,yPosition);
        Instantiate(lootBox,spawnPosition,Quaternion.identity);
        Invoke("LootBoxSpawn", randomTime);
    }
}
