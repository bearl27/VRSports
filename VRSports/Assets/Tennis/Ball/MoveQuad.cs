using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveQuad : MonoBehaviour
{
    private float maxX = 8.0f;
    private float minX = -8.0f;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            transform.position = new Vector3(Random.Range(minX, maxX), 0, 0);
        }
    }
}
