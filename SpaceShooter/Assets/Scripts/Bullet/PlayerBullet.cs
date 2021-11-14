using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 8f;
    public int damage = 10;

    void Start()
    { }

    void Update()
    {
        UpdatePosition();
        CheckOutOfScreen();
    }

    void OnTriggerEnter2D(Collider2D coll) 
    {
        switch (coll.tag)
        {
            case "Enemy":
                coll.GetComponent<EnemyHealthController>().TakeDamage(damage);
                Destroy(gameObject);
                break;
            case "Asteroid":
                Destroy(gameObject);
                break;
        }
    }

    private void UpdatePosition()
    {
        transform.position = new Vector2(
            transform.position.x, 
            transform.position.y + speed * Time.deltaTime
            );
    }

    private void CheckOutOfScreen()
    {
        if (transform.position.y > GameConfig.maxCoords.y || transform.position.y < GameConfig.minCoords.y ||
            transform.position.x > GameConfig.maxCoords.x || transform.position.x < GameConfig.minCoords.x)
        {
            Destroy(gameObject);
        }
    }
}
