using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaceBall : MonoBehaviour
{
    public GameObject ballPrefab; // インスペクターでBallPrefabをアサインします
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            // BallPrefabを元にBallオブジェクトを生成
            Instantiate(ballPrefab, new Vector3(0, 0, -5), Quaternion.identity);
        }
    }
}
