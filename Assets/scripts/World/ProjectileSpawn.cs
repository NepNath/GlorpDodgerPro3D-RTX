using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{

    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private float minRadius;   
    [SerializeField] private float maxRadius;   

    [SerializeField] private float spawnInterval;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnProjectile();
            timer = 0f;
        }
    }

    void SpawnProjectile()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minRadius, maxRadius);

        Vector2 spawnPoint = randomDirection * randomDistance;

        Vector3 SpawnPosition = new Vector3(spawnPoint.x, 0f, spawnPoint.y) + transform.position;

        Instantiate(spawnPrefab, SpawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
    }
}
