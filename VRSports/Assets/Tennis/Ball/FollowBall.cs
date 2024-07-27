using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public string targetName = "TargetObject"; // 追尾対象のGameObject名
    public float force = 5f; // 力の大きさ（インスペクターで調整可能）
    public float maxSpeed = 5f; // 最大速度（インスペクターで調整可能）

    private Rigidbody rb; // BallのRigidbody
    private GameObject target; // 追尾対象

    void Start()
    {
        // BallのRigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogWarning("Rigidbodyコンポーネントが見つかりません。BallオブジェクトにRigidbodyを追加してください。");
        }

        // 指定された名前のGameObjectを見つける
        target = GameObject.Find(targetName);

        if (target == null)
        {
            Debug.LogWarning($"'{targetName}'という名前のオブジェクトが見つかりません。");
        }
    }

    void FixedUpdate()
    {
        if (rb != null && target != null)
        {
            // BallからTargetへの3D方向ベクトルを計算
            Vector3 direction = (target.transform.position - transform.position).normalized;

            // 現在の速度を取得
            Vector3 currentVelocity = rb.velocity;

            // 目標速度を計算（方向 * 最大速度）
            Vector3 targetVelocity = direction * maxSpeed;

            // 現在の速度と目標速度の差分を計算
            Vector3 velocityChange = targetVelocity - currentVelocity;

            // 速度変化に力を加える
            rb.AddForce(velocityChange * force, ForceMode.Acceleration);

            // 最大速度を制限
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }
}