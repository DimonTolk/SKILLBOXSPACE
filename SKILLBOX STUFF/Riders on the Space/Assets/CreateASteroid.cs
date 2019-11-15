using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateASteroid : MonoBehaviour
{
    float minDelay = 0.6f, maxDelay = 1.0f;
    public GameObject asteroid;
    private float nextAsteroid;
    void Update()
    {
        var positionZ = transform.position.z;
        var positionY = transform.position.y;
        var positionX = Random.Range(-133,133);
        var position = new Vector3(positionX, positionY, positionZ);
        if (Time.time>nextAsteroid)
        {
            Instantiate(asteroid,position,Quaternion.identity);
            nextAsteroid = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
