using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D enemy;
    float moveSpeed = 3f;
    public float heathAmount;
    public float decHealth;
    private Transform target;
    public static int counter;
    
    //Vector2 moveleft = new Vector2(-1,0);
    
    // Start is called before the first frame update
    void Start()
    {
        heathAmount = 6;
        decHealth = 3;
        enemy = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(heathAmount <= 0)
            Destroy(gameObject);

        if(transform.position.x > target.position.x){
            transform.Translate(Vector3.left*moveSpeed*Time.deltaTime);
            //transform.Translate(moveleft*moveSpeed*Time.deltaTime);
        }else{
            transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);
            //transform.Translate(-moveleft*moveSpeed*Time.deltaTime);
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Player") {
            heathAmount -= decHealth * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Bullet")){
            Destroy(gameObject);
            Destroy(other.gameObject);
            counter++;
        }else if(other.gameObject.CompareTag("Sword")){
            Destroy(gameObject);
        }
    }
    
}
