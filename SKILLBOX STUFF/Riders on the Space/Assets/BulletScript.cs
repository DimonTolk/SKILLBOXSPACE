using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float speed = 20f;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * speed;
    }
}
