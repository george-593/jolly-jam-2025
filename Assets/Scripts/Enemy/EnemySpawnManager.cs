using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private XPManager xPManager;

    [Header("Spawn Area Settings")]
    [SerializeField] private float minSpawnRadius = 10f;
    [SerializeField] private float maxSpawnRadius = 30f;

    public GameObject[] enemyPrefabs;
    public float spawnInterval = 2f;
    public int maxEnemies = 100;

    private float spawnTimer = 0f;
    private List<GameObject> activeEnemies = new List<GameObject>();

    public void SetSpawnInterval(float newInterval)
    {
        spawnInterval = Mathf.Clamp(newInterval, 0.1f, 10f);
    }

    public void AddEnemyType(GameObject newEnemy)
    {
        activeEnemies.Add(newEnemy);
    }

    void Update()
    {
        // Remove all dead enemies from activeEnemies
        activeEnemies.RemoveAll(item => item == null);

        // Spawn enemies
        if (activeEnemies.Count < maxEnemies)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Vector2 spawnPos = GetRandomSpawnPos();
        GameObject enemy = Instantiate(enemyToSpawn, spawnPos, Quaternion.identity);
        EnemyController controller = enemy.GetComponent<EnemyController>();
        controller.target = player;
        controller.xPManager = xPManager;
        activeEnemies.Add(enemy);
    }

    private Vector2 GetRandomSpawnPos()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        float randomDist = Random.Range(minSpawnRadius, maxSpawnRadius);
        return (Vector2)player.position + (randomDir * randomDist);
    }
}
