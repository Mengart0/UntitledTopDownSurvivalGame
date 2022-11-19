using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public int bulletDamage = 40;
    
    public Player player;

    public GameObject WeaponAim;

    private void Start()
    {
        InvokeRepeating("Shoot", 0f, 2f);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        RotateWeapon();
    }

    //Turning the firepoint on our player PreFAB towards the closest enemy 
    void RotateWeapon()
    {
        Vector2 cenemy = player.closestEnemy.transform.position - this.transform.position;
        
        //Quaternion AimAt = (cenemy.x, cenemy.y, 0f)
        //firepoint.rotation = (cenemy.x, cenemy.y, 0f);

        var angle = Mathf.Atan2(cenemy.y, cenemy.x) * Mathf.Rad2Deg;
        WeaponAim.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }


    void ClosestShoot()  //discontinued 
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);  //Character doesn't turn so it has no rotation
        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();  //Need to direct it to the closest enemy direction
        Vector2 cenemy = player.closestEnemy.transform.position - this.transform.position;
        Debug.Log(cenemy);
        bulletBody.AddForce(cenemy, ForceMode2D.Impulse);
    }


    //Instantiating a bullet PreFAB then adding force to it forwards
    void Shoot() 
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
