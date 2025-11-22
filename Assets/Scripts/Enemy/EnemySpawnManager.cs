using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private Transform player;

    [Header("Enemy Settings")]
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int maxEnemies = 100;

    [Header("Spawn Area Settings")]
    [SerializeField] private float minSpawnRadius = 10f;
    [SerializeField] private float maxSpawnRadius = 30f;

    private float spawnTimer = 0f;
    private List<GameObject> activeEnemies = new List<GameObject>();

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
        enemy.GetComponent<EnemyController>().target = player;
        activeEnemies.Add(enemy);
    }

    private Vector2 GetRandomSpawnPos()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        float randomDist = Random.Range(minSpawnRadius, maxSpawnRadius);
        return (Vector2)player.position + (randomDir * randomDist);
    }
}
