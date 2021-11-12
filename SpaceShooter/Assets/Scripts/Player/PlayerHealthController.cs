using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public int MaxHP = 100;
    public int HP { get; private set; }

    void Start()
    {
        HP = MaxHP;
    }

    void Update()
    {
        if (IsDead())
        {
            SceneManager.LoadScene(0);
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        // if (IsDead())
        // {
        //     Destroy(gameObject);
        // }
    }

    private bool IsDead()
    {
        return HP <= 0;
    }
}