using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    private PressedState jumpButton;
    private float jumpHeight = 7.0f;
    private bool jump = false;
    public Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        jumpButton = FindObjectOfType<PressedState>();
        playerRB.freezeRotation = true;
        //playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!jump && jumpButton.pressed){
            jump=true;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpHeight);
        }
        if (jump && !jumpButton.pressed){
            jump=false;
        }
    }     
        /*if(Input.GetMouseButton(0)){
            playerRB.velocity = new Vector2(playerRB.velocity.x,3);
        }
    

    /*void GoRight(){
        playerRB.velocity = new Vector2(3,playerRB.velocity.y);
    }

    void GoLeft(){
        playerRB.velocity = new Vector2(-3,playerRB.velocity.y);
    }*/

    
}
