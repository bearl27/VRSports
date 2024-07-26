using UnityEngine;

public class Target : MonoBehaviour
{
    void Start()
    {
        TargetManager.ExistTarget = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TargetManager.ExistTarget = false;
            //スコアを加算
            Score.AddScore();
            //3秒後に消す
            Destroy(gameObject, 1.0f);
        }
    }


}