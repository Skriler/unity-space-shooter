using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    
    public float minSpawnTimeFirst = 1f;
    public float maxSpawnTimeFirst = 3f;

    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 4f;

    public float minEnemySpeed = 0.3f;
    public float maxEnemySpeed = 1f;

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

        GameObject curEnemy = Instantiate(enemy, spawnPos, Quaternion.identity);
        curEnemy.GetComponent<EnemyMovement>().speed = Random.Range(minEnemySpeed, maxEnemySpeed);
    }
}
