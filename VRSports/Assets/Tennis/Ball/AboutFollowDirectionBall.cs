using UnityEngine;

public class AboutFollowDirectionBall : MonoBehaviour
{
    public string targetName = "TargetObject"; // 方向を決めるためのターゲットオブジェクト名
    public float speed = 5f; // 移動速度（インスペクターで調整可能）

    private Rigidbody rb; // BallのRigidbody
    private Vector3 moveDirection; // 移動方向
    [SerializeField] private float rangeX = 2.0f;
    private Vector3 targetPosition;

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

        targetPosition = target.transform.position;
        targetPosition.x += Random.Range(-rangeX, rangeX);
        // ターゲットへの方向を即座に計算（正規化済み）
        moveDirection = (targetPosition - transform.position).normalized;

        // 初速度を設定
        rb.velocity = moveDirection * speed;
    }

    void FixedUpdate()
    {
        // 常に一定の速度で移動方向に進む
        rb.velocity = moveDirection * speed;
    }
}