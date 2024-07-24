using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int hitCount = 0;
    public Material[] materials;
    private Rigidbody rb;

    void Start()
    {
        hitCount = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            hitCount++;
        }

        if (hitCount == 1)
        {
            GetComponent<Renderer>().material = materials[0];
            Debug.Log("Hit1");
        }
        else if (hitCount == 2)
        {
            GetComponent<Renderer>().material = materials[1];
            Debug.Log("Hit2");
        }
        else if (hitCount == 3)
        {
            rb.isKinematic = false;
            Debug.Log("Hit3");
        }
    }

}
