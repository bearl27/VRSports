using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public static Vector3 ballPos;
    private float speed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 初期速度を設定
        rb.velocity = Vector3.forward * speed;
    }

    void FixedUpdate()
    {
        // 速度を一定に保つ
        rb.velocity = rb.velocity.normalized * speed;
        ballPos = transform.position;

        if (ballPos.y < -10) // 落下の閾値を調整
        {
            Destroy(gameObject);
        }
    }
}