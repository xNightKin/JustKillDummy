using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum Modes {Sword, Gun}
    public GameObject projectilePrefab;
    public static float coolDown=0.5f;
    public Sprite sprite;
    public Modes weaponMode;
    public float projectileSpeed = 5f;
    // Start is called before the first frame update
   
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
