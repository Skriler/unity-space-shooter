using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] backgrounds;

    public float minCoordX = -5f;
    public float maxCoordX = 5f;

    private float shiftY = 4f;

    void Start() 
    {
        SpawnBackground();
    }

    void SpawnBackground()
    {
        int index = Random.Range(0, backgrounds.GetLength(0));

        Vector2 spawnPos = new Vector2(
            Random.Range(minCoordX, maxCoordX), 
            GameConfig.maxCoords.y + shiftY
            );

        Instantiate(backgrounds[index], spawnPos, Quaternion.identity);
    }
}
