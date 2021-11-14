using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int scoreCost = 50;
    public int MaxHP = 50;
    public int collDamage = 10;
    public int HP { get; private set; }

    private Animator animatorComponent;

    void Start()
    {
        HP = MaxHP;
        animatorComponent = gameObject.GetComponent<Animator>();
    }

    void Update()
    { }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.transform.tag == "Player")
        {
            TakeDamage(collDamage);
            coll.gameObject.GetComponent<PlayerHealthController>().TakeDamage(collDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (IsDead())
            SetDead();
    }

    private void SetDead()
    {
        ScoreController.AddScore(scoreCost);
        animatorComponent.SetTrigger("IsDead");
        gameObject.GetComponent<EnemyFire>().enabled = false;
        gameObject.GetComponent<EnemyMovement>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Invoke("DestroyEnemy", 0.5f);
    }

    private void DestroyEnemy() 
    {
        Destroy(gameObject);
    }

    private bool IsDead()
    {
        return HP <= 0;
    }
}
