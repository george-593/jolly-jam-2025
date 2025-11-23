using UnityEngine;
using System.Collections.Generic;

public class ItemSpawnManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject warmthObject;

    [Header("Spawn Area Settings")]
    [SerializeField] private float minSpawnRadius = 15f;
    [SerializeField] private float maxSpawnRadius = 40f;

    public GameObject[] itemPrefabs;
    public float spawnInterval = 10f;
    public int maxItems = 20;

    private float spawnTimer = 0f;
    private List<GameObject> activeItems = new List<GameObject>();

    public void SetSpawnInterval(float newInterval)
    {
        spawnInterval = Mathf.Clamp(newInterval, 0.1f, 10f);
    }

    void Update()
    {
        // Remove all used items from activeItems
        activeItems.RemoveAll(item => item == null);

        // Spawn items
        if (activeItems.Count < maxItems)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnItem();
                spawnTimer = 0f;
            }
        }
    }

    private void SpawnItem()
    {
        GameObject itemToSpawn;
        if (playerTransform.GetComponent<PlayerController>().warmth <= 25)
        {
            itemToSpawn = warmthObject;
        }
        else
        {
            itemToSpawn = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
        }
        Vector2 spawnPos = GetRandomSpawnPos();
        GameObject item = Instantiate(itemToSpawn, spawnPos, Quaternion.identity);
        activeItems.Add(item);
    }

    private Vector2 GetRandomSpawnPos()
    {
        Vector2 randomDir = Random.insideUnitCircle.normalized;
        float randomDist = Random.Range(minSpawnRadius, maxSpawnRadius);
        return (Vector2)playerTransform.position + (randomDir * randomDist);
    }
}
