using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] projectileList;
    [SerializeField] private float minRadius;
    [SerializeField] private float maxRadius;

    [SerializeField] private bool showSpawnRadius;

    [SerializeField] private float spawnInterval;
    private float timer;


    public void projectileSpawnTimer(float timer)
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnProjectile();
            timer = 0f;
        }
    }


    public void SpawnProjectile()
    {
        int randomProjectile = Random.Range(0, GameSettings.difficultyIndex);
        Instantiate(projectileList[randomProjectile], generateRandomSpawnPoint(), Quaternion.identity);
    }


    private Vector3 generateRandomSpawnPoint()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minRadius, maxRadius);

        Vector2 spawnPoint = randomDirection * randomDistance;
        Vector3 SpawnPosition = new Vector3(spawnPoint.x, 0f, spawnPoint.y) + transform.position;
        return SpawnPosition;
    }

    private void OnDrawGizmos()
    {
        if (showSpawnRadius)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, minRadius);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, maxRadius);
        }

    }
}
