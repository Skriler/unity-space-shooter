using UnityEngine;

public class Planet : MonoBehaviour
{
    public float speed = 0.1f;
    public float accuracy = 0.5f;

    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = new Vector2(
            transform.position.x,
            transform.position.y - speed * Time.deltaTime
            );

        if (transform.position.y + accuracy < GameConfig.minCoords.y)
        {
            Destroy(gameObject);
        }
    }
}
