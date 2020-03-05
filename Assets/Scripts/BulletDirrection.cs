using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirrection : MonoBehaviour
{
    /*public float moveSpeed = 40.0f;
    // Start is called before the first frame update
    Vector2 moveleft = new Vector2(-1,0);
    Vector2 moveRight = new Vector2(1,0);
    private Joystick joystick;*/
    private float outOfBoundPossition = 15f;
    void Start()
    {
        //joystick=GameObject.FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x < -outOfBoundPossition || gameObject.transform.position.x > outOfBoundPossition)
        Destroy(gameObject);
        /*if(joystick.rightside)
        transform.Translate(moveleft*moveSpeed*Time.deltaTime);
        else
        transform.Translate(moveRight*moveSpeed*Time.deltaTime);*/
    }
    
}
