using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    // Start is called before the first frame update
    float speedRotation = 5f;
    float speed1 = 25f;
    float speed2 = 35f;
    public GameObject ExpAst;
    public GameObject PlayerExp;
    void Start()
    {
        var asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * speedRotation;
        asteroid.velocity = Vector3.back * Random.Range(speed1,speed2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Border"|| other.tag =="Asteroid")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(PlayerExp, transform.position, Quaternion.identity);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(ExpAst, transform.position, Quaternion.identity);
    }
}
