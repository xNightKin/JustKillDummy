using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ladder : MonoBehaviour
{
    private float fallSpeed = 4.0f;
    private float yPos = 1.5f;
    private float climbSpeed = 6.0f;
    // Start is called before the first frame update
    public static bool allowToMoveRLWhileClimb = true;
    private int sceneIndex;
    public static int levelGoal;
    private bool nextLevel = false;
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < yPos){
            transform.position = new Vector3(transform.position.x,yPos, transform.position.z);
        }
        if(sceneIndex ==2){
            levelGoal = 20;
            if(EnemyController.counter >=levelGoal){
                transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
            }
        }else if(sceneIndex ==4){
            levelGoal = 50;
            if(EnemyController.counter >=levelGoal){
                transform.Translate(Vector3.down * Time.deltaTime * fallSpeed);
            }
        }
        if(nextLevel){
            EnemyController.counter=0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            allowToMoveRLWhileClimb = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player" && Joystick.moveUp){
            allowToMoveRLWhileClimb = false;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0,climbSpeed);
            Debug.Log(other.GetComponent<Rigidbody2D>().position.y);
            if(other.GetComponent<Rigidbody2D>().position.y > 6){
                nextLevel = true;
            }
        }
    }
}
