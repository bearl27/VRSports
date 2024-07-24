using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject ballPrefab;
    private Vector3 mousePos;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Get the mouse position
            mousePos = Input.mousePosition;
            mousePos.z = 5f;
            // Create a new ball
            Instantiate(ballPrefab, Camera.main.ScreenToWorldPoint(mousePos), Quaternion.identity);
        }
    }

}
