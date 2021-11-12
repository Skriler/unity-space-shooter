using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    
    public float minSpawnTimeFirst = 1f;
    public float maxSpawnTimeFirst = 3f;

    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 7f;

    private float shiftY = 0.2f;

    void Start()
    {
        InvokeRepeating(
            "SpawnEnemy", 
            Random.Range(minSpawnTimeFirst, maxSpawnTimeFirst), 
            Random.Range(minSpawnInterval, maxSpawnInterval)
            );
    }

    void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(
            Random.Range(GameConfig.minCoords.x, GameConfig.maxCoords.x), 
            GameConfig.maxCoords.y + shiftY
            );

        Instantiate(enemy, spawnPos, Quaternion.identity);
    }
}
