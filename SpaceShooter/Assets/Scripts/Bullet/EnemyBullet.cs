using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 4f;
    public int damage = 25;

    private Vector2 direction;

    void Start()
    { }

    void Update()
    {
        UpdatePosition();
        CheckOutOfScreen();
    }

    void OnTriggerEnter2D(Collider2D coll) 
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<PlayerHealthController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void UpdatePosition()
    {
        Vector2 position = transform.position;

        position += direction * speed * Time.deltaTime;

        transform.position = position;
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
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
