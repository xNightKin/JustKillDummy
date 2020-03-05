using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
    public Transform player;
    public float speed = 10.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    public Transform circle;
    public float xRange=5f;
    public bool rightside = true;
    public static bool moveUp = false;
    public Text counterText;
    private int sceneIndex;

    private void Start() {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    // Update is called once per frame
    void Update()
    {        
        //Debug.Log(Input.GetMouseButtonDown(0));
        //Debug.Log(Screen.width/2);
        if(sceneIndex ==2 || sceneIndex ==4 )
            counterText.text = "Killed enemy: " + EnemyController.counter.ToString() + "\n Goal: " + Ladder.levelGoal;
        if(Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width/2 && Input.touchCount == 1){
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            //Debug.Log("x="+Input.mousePosition.x);
            //Debug.Log(Camera.main.transform.position.y+2);
           // pointA = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z));
            circle.GetComponent<SpriteRenderer>().enabled=true;
        }
        if(Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width/2 && Input.touchCount == 1){
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }else{
            touchStart = false;
        }
    }
    private void FixedUpdate(){
        if(touchStart && Input.mousePosition.x < Screen.width/2){
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            if(sceneIndex ==2 || sceneIndex ==4){
                if(offset.y>0){
                    moveUp = true;
                }else if(offset.y<0){
                    moveUp = false;
                }
                if(offset.x>0 && Ladder.allowToMoveRLWhileClimb){
                    rightside = true;
                    moveCharacter(new Vector2(-direction.x,0));
                    transform.eulerAngles = Vector3.up * -180;
                    //Debug.Log(direction);
                }else if(offset.x<0 && Ladder.allowToMoveRLWhileClimb){
                    rightside = false;
                    transform.eulerAngles = Vector3.up * 0;
                    moveCharacter(new Vector2(direction.x,0));
                }
            }
            if(sceneIndex ==1 || sceneIndex ==3){
                moveCharacter(new Vector2(direction.x,0));
            }
            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y);
        }else{
            circle.GetComponent<SpriteRenderer>().enabled=false;
        }
	}
	void moveCharacter(Vector2 direction){
        if(sceneIndex ==2 || sceneIndex ==4){
            if(transform.position.x < -xRange)
                transform.position = new Vector3(-xRange,transform.position.y, transform.position.z);
            if(transform.position.x > xRange)
                transform.position = new Vector3(xRange,transform.position.y, transform.position.z);
        }
        player.Translate(direction * speed * Time.deltaTime);
    }
}
