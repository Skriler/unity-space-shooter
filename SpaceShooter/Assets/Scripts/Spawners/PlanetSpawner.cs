using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    
    public float minSpawnTimeFirst = 1f;
    public float maxSpawnTimeFirst = 4f;

    public float minSpawnInterval = 15f;
    public float maxSpawnInterval = 35f;

    public float minPlanetSpeed = 0.01f;
    public float maxPlanetSpeed = 0.5f;

    public float minScale = 0.01f;
    public float maxScale = 0.5f;

    void Start() 
    {
        InvokeRepeating(
            "SpawnPlanet", 
            Random.Range(minSpawnTimeFirst, maxSpawnTimeFirst), 
            Random.Range(minSpawnInterval, maxSpawnInterval)
            );
    }

    void SpawnPlanet()
    {
        int index = Random.Range(0, planets.GetLength(0));
        float scale = Random.Range(minScale, maxScale);
        float shiftY = scale * 10;

        Vector2 spawnPos = new Vector2(
            Random.Range(GameConfig.minCoords.x, GameConfig.maxCoords.x), 
            GameConfig.maxCoords.y + shiftY
            );

        GameObject planet = Instantiate(planets[index], spawnPos, Quaternion.identity);

        planet.transform.localScale = new Vector3(scale, scale, scale);
        planet.GetComponent<Planet>().speed = Random.Range(minPlanetSpeed, maxPlanetSpeed);
        planet.GetComponent<Planet>().accuracy = scale * 10;
    }
}
