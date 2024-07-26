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
            //3秒後に消す
            Destroy(gameObject, 2.0f);
        }
    }


}