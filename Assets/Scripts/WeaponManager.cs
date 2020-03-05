using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private PressedState fireButton;
    public GameObject activeWeapon;
    Weapon weapon;
    Joystick joystick;
    public float nextFireTime;
    public bool canShoot=true;
    // Start is called before the first frame update
    void Start()
    {
        fireButton = FindObjectOfType<PressedState>();
        weapon = activeWeapon.GetComponent<Weapon>();
        GetComponent<SpriteRenderer>().sprite = weapon.sprite;
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon.weaponMode == Weapon.Modes.Sword){
            fireButton.enabled =false;
        }else if(weapon.weaponMode == Weapon.Modes.Gun){
            fireButton.enabled=true;
        }
        //if(Time.time > nextFireTime){
            if(fireButton.pressed && canShoot){
                //nextFireTime = Time.time + weapon.coolDown;
                canShoot = false;
                StartCoroutine("CoolDown");
                Vector3 rotation = !joystick.rightside ?Vector3.zero : Vector3.up*-180;
                GameObject projective = (GameObject) Instantiate(weapon.projectilePrefab,transform.position+ activeWeapon.transform.GetChild(0).localPosition * transform.parent.localScale.x,Quaternion.Euler(rotation));
                if(weapon.weaponMode == Weapon.Modes.Gun){
                    if(joystick.rightside){
                        projective.GetComponent<Rigidbody2D>().velocity = transform.parent.localScale.x*Vector2.right*weapon.projectileSpeed;
                    }else{
                        projective.GetComponent<Rigidbody2D>().velocity = transform.parent.localScale.x*Vector2.left*weapon.projectileSpeed;
                    }
                }
            }
        //}
    }
    IEnumerator CoolDown(){
        yield return new WaitForSeconds(Weapon.coolDown);
        canShoot=true;
    }

    public void UpdateWeapon(GameObject newWeapon){
        activeWeapon = newWeapon;
        weapon = activeWeapon.GetComponent<Weapon>();
        GetComponent<SpriteRenderer>().sprite = weapon.sprite;
       
    }
}