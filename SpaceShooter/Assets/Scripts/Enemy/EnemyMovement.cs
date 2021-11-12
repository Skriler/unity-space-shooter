using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Speed")]
    public float speed = 0.5f;

    void Start()
    { }

    void Update()
    {
        UpdatePosition();
        CheckOutOfScreen();
    }

    private void UpdatePosition()
    {
        transform.position = new Vector2(
            transform.position.x, 
            transform.position.y - speed * Time.deltaTime
            );
    }

    private void CheckOutOfScreen()
    {
        if (transform.position.y < GameConfig.minCoords.y)
            Destroy(gameObject);
    }
}
