using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    [SerializeField] private EnemySpawnManager spawnManager;

    [Header("Settings")]
    [Tooltip("How the spawn rate changes over time (X = Time in Minutes, Y = Spawn Rate)")]
    [SerializeField] private AnimationCurve spawnRateCurve;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        float timeInMins = timer / 60f;

        float newSpawnRate = spawnRateCurve.Evaluate(timeInMins);
        Debug.Log(newSpawnRate);
        spawnManager.SetSpawnInterval(newSpawnRate);
    }
}
