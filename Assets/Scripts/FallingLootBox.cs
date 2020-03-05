using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLootBox : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject randomWeapon;
    public float moveSpeed =5f;
    private float destroyTime = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        randomWeapon = weapons [Random.Range(0,weapons.Length)];

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*moveSpeed*Time.deltaTime);
        Destroy(gameObject,destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            other.transform.Find("WeaponSlot").GetComponent<WeaponManager>().UpdateWeapon(randomWeapon);
            Destroy(gameObject);
        }
    }
}
