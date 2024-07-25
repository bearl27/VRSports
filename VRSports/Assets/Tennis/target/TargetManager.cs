using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static bool existTarget = false;
    public GameObject targetPrefab;
    private float targetMaxX = 5.0f;
    private float targetMinX = -5.0f;
    private float targetMaxY = 1.0f;
    private float targetMinY = 0.0f;

    void Start()
    {
        existTarget = false;
    }

    void Update()
    {
        if (!existTarget)
        {
            SetTarget();
        }
    }

    private void SetTarget()
    {
        Vector3 targetPosition = new Vector3(
            Random.Range(targetMinX, targetMaxX),
            Random.Range(targetMinY, targetMaxY),
            0
        );

        Instantiate(targetPrefab, targetPosition, Quaternion.identity);
        existTarget = true;
    }

    public static void setExistTarget(bool exist)
    {
        existTarget = exist;
    }

    public static bool getExistTarget()
    {
        return existTarget;
    }
}