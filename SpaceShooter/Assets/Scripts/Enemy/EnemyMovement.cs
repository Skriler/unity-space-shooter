using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Speed")]
    public float speed = 0.5f;
    public float oneSideMovementRate = 5f;

    private float accuracy = 0.5f;
    private bool isLeftSide;
    private float curTimeout;

    void Start()
    { 
        isLeftSide = System.Convert.ToBoolean(Random.Range(0, 2));
        oneSideMovementRate = Random.Range(1f, 5f);
    }

    void Update()
    {
        UpdatePosition();
        CheckOutOfScreen();
    }

    private void UpdatePosition()
    {
        curTimeout += Time.deltaTime;

        if (curTimeout >= oneSideMovementRate)
        {
            isLeftSide = !isLeftSide;
            curTimeout = 0;
            oneSideMovementRate = Random.Range(1f, 5f);
        }

        float posX = isLeftSide ? -speed : speed;
        posX *= Time.deltaTime;
        posX += transform.position.x;

        posX = posX > GameConfig.maxCoords.x ? GameConfig.maxCoords.x : posX;
        posX = posX < GameConfig.minCoords.x ? GameConfig.minCoords.x : posX;

        transform.position = new Vector2(
            posX, 
            transform.position.y - speed * Time.deltaTime
            );
    }

    private void CheckOutOfScreen()
    {
        if (transform.position.y + accuracy < GameConfig.minCoords.y)
            Destroy(gameObject);
    }
}
