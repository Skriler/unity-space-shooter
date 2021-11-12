using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int scoreCost = 50;
    public int MaxHP = 50;
    public int HP { get; private set; }

    void Start()
    {
        HP = MaxHP;
    }

    void Update()
    { }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.transform.tag == "Player")
        {
            TakeDamage(10);
            coll.gameObject.GetComponent<PlayerHealthController>().TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (IsDead())
        {
            ScoreController.AddScore(scoreCost);
            Destroy(gameObject);
        }
    }

    private bool IsDead()
    {
        return HP <= 0;
    }
}
