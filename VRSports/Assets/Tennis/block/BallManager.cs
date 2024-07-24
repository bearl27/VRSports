using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Rigidbody rb;
    public static Vector3 ballPos;
    public static bool ballGo = false;


    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(0,10,50);
        rb.AddTorque(10,0,0);
        ballGo = true;
        ballPos = transform.position;
        if (ballPos.y < 0) {
            Destroy(gameObject);
            ballGo = false;
        }
    }
}
