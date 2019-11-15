using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody PlayerRb;
    public GameObject flame;
    readonly float speed = 45f;
    int xMax, xMin, zMin, zMax;
    public GameObject bullet;
    public GameObject gun;
    float delay = 0.25f;
    private float nextShot;
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        xMax = 27;
        xMin =-27;
        zMax = 37;
        zMin = -42;
    }

    
    void Update()
    {
        PlayerRb.rotation = Quaternion.Euler(0, 0, 0);
        var hor = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");

        flame.SetActive((vert != 0 || hor!=0) ? true : false);

        PlayerRb.velocity = new Vector3(hor, 0, vert) * speed;

        PlayerRb.rotation = Quaternion.Euler(PlayerRb.velocity.z*0.9f,0,-PlayerRb.velocity.x*0.9f);

        float posX = Mathf.Clamp(PlayerRb.position.x, xMin, xMax);
        float posZ = Mathf.Clamp(PlayerRb.position.z, zMin, zMax);

        PlayerRb.position = new Vector3(posX, 0, posZ);
        Shoot();
    }
    void Shoot()
    {
        if (Time.time>nextShot && Input.GetButton("Fire1"))
        {
            Instantiate(bullet, gun.transform.position, Quaternion.identity);
            nextShot = Time.time + delay;
        }
        
    }
}
