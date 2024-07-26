using UnityEngine;
using System.Collections;

public class TargetManager : MonoBehaviour
{
    private static bool _existTarget = false;
    public static bool ExistTarget
    {
        get { return _existTarget; }
        set { _existTarget = value; }
    }
    public GameObject targetPrefab;
    private float targetMaxX = 5.0f;
    private float targetMinX = -5.0f;
    private float targetMaxY = 2.0f;
    private float targetMinY = 0.5f;
    [SerializeField] private float respawnDelay = 1.0f;
    [SerializeField] private Color endColor = Color.blue;

    void Start()
    {
        ExistTarget = false;
        SetTarget();
    }

    void Update()
    {
        if (!ExistTarget)
        {
            StartCoroutine(RespawnTarget());
        }
    }

    private IEnumerator RespawnTarget()
    {
        ExistTarget = true;
        yield return new WaitForSeconds(respawnDelay);
        SetTarget();
    }

    private void SetTarget()
    {
        Vector3 targetPosition = new Vector3(
            Random.Range(targetMinX, targetMaxX),
            Random.Range(targetMinY, targetMaxY),
            -1.0f
        );

        GameObject spawnedTarget = Instantiate(targetPrefab, targetPosition, Quaternion.identity);
        ExistTarget = true;
        StartCoroutine(SpawnEffect(spawnedTarget));
    }

    private IEnumerator SpawnEffect(GameObject target)
    {
        Renderer renderer = target.GetComponent<Renderer>();
        if (renderer != null)
        {
            float duration = 0.5f;
            float elapsedTime = 0f;
            Color startColor = Color.white;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;
                renderer.material.color = Color.Lerp(startColor, endColor, t);
                yield return null;
            }

            renderer.material.color = endColor;
        }
    }
}