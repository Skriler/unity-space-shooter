using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 0.1f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

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

        if (transform.position.y < GameConfig.minCoords.y)
        {
            transform.position = startPos;
        }
    }
}
