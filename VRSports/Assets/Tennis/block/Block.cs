using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private int hitCount = 0;
    public Material[] materials;
    private Rigidbody rb;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip destroySound;

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
            AudioSource.PlayClipAtPoint(hitSound, collision.GetContact(0).point);
           // Debug.Log("Hit1");
        }
        else if (hitCount == 2)
        {
            GetComponent<Renderer>().material = materials[1];
            AudioSource.PlayClipAtPoint(hitSound, collision.GetContact(0).point);
           // Debug.Log("Hit2");
        }
        else if (hitCount == 3)
        {
            rb.isKinematic = false;
            rb.AddForce(Vector3.forward * 5, ForceMode.Impulse);
            AudioSource.PlayClipAtPoint(destroySound, collision.GetContact(0).point);
            //Debug.Log("Hit3");
        }
    }

}
