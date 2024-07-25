using UnityEngine;

public class Target : MonoBehaviour
{
    void Start()
    {
        TargetManager.setExistTarget(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TargetManager.setExistTarget(false);
            Destroy(gameObject);
        }
    }
}