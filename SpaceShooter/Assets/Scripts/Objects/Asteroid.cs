using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 0.5f;
    public float accuracy = 2f;
    public int collDamage = 50;

    private float rotZ = 0;
    public float RotationSpeed = 200;

    private bool isDead = false;

    private Animator animatorComponent;

    void Start()
    {
        animatorComponent = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
            UpdatePosition();
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        switch (coll.transform.tag)
        {
            case "Player":
                coll.gameObject.GetComponent<PlayerHealthController>().TakeDamage(collDamage);
                SetDestroyed();
                break;
            case "Enemy":
                coll.gameObject.GetComponent<EnemyHealthController>().TakeDamage(collDamage);
                SetDestroyed();
                break;
        }
    }

    private void UpdatePosition()
    {
        rotZ += Time.deltaTime * RotationSpeed;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        transform.position = new Vector2(
            transform.position.x + speed * Time.deltaTime,
            transform.position.y
            );

        if (transform.position.x - accuracy > GameConfig.maxCoords.x)
        {
            DestroyAsteroid();
        }
    }

    private void SetDestroyed()
    {
        animatorComponent.SetTrigger("IsDestroyed");
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        isDead = true;
        Invoke("DestroyAsteroid", 0.5f);
    }

    private void DestroyAsteroid() 
    {
        Destroy(gameObject);
    }
}
