using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    
    public float minSpawnTimeFirst = 8f;
    public float maxSpawnTimeFirst = 14f;

    public float minSpawnInterval = 10f;
    public float maxSpawnInterval = 45f;

    public float minAsteroidSpeed = 0.2f;
    public float maxAsteroidSpeed = 3f;

    public float scale = 0.6f;

    void Start() 
    {
        InvokeRepeating(
            "SpawnAsteroid", 
            Random.Range(minSpawnTimeFirst, maxSpawnTimeFirst),
            Random.Range(minSpawnInterval, maxSpawnInterval)
            );
    }

    void SpawnAsteroid()
    {
        float shiftX = scale * 2;

        Vector2 spawnPos = new Vector2(
            GameConfig.minCoords.x - shiftX,
            Random.Range(GameConfig.minCoords.y, GameConfig.maxCoords.y)   
            );

        GameObject curAsteroid = Instantiate(asteroid, spawnPos, Quaternion.identity);

        curAsteroid.transform.localScale = new Vector3(scale, scale, scale);
        curAsteroid.GetComponent<Asteroid>().speed = Random.Range(minAsteroidSpeed, maxAsteroidSpeed);
        curAsteroid.GetComponent<Asteroid>().accuracy = scale * 2;
    }
}
