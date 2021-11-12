using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Speed")]
    public float speed = 4f;

    void Start()
    { }

    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y);

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, GameConfig.minCoords.x, GameConfig.maxCoords.x);
        pos.y = Mathf.Clamp(pos.y, GameConfig.minCoords.y, GameConfig.maxCoords.y);

        transform.position = pos;
    }
}
