using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathBar : MonoBehaviour
{
    Vector3 healthBarScale;
    private EnemyController enemyController;
    // Start is called before the first frame update
    void Start()
    {
        healthBarScale = transform.localScale;
        enemyController = FindObjectOfType<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBarScale.x=enemyController.heathAmount;
        //Debug.Log(healthBarScale);
        transform.localScale=healthBarScale;
    }
}
