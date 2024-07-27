using UnityEngine;

public class FollowDirectionBall : MonoBehaviour
{
    public string targetName = "TargetObject"; // 方向を決めるためのターゲットオブジェクト名
    public float speed = 5f; // 移動速度（インスペクターで調整可能）

    private Rigidbody rb; // BallのRigidbody
    private Vector3 moveDirection; // 移動方向

    void Start()
    {
        // BallのRigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbodyコンポーネントが見つかりません。BallオブジェクトにRigidbodyを追加してください。");
            return;
        }

        // 指定された名前のGameObjectを見つける
        GameObject target = GameObject.Find(targetName);

        if (target == null)
        {
            Debug.LogError($"'{targetName}'という名前のオブジェクトが見つかりません。");
            return;
        }

        // ターゲットへの方向を即座に計算（正規化済み）
        moveDirection = (target.transform.position - transform.position).normalized;

        // 初速度を設定
        rb.velocity = moveDirection * speed;
    }

    void FixedUpdate()
    {
        // 常に一定の速度で移動方向に進む
        rb.velocity = moveDirection * speed;
    }
}