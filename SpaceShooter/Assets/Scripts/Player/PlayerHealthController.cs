using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : MonoBehaviour
{
    public int MaxHP = 100;
    public int HP { get; private set; }

    private Animator animatorComponent;
    private Vector3 startPos;

    void Start()
    {
        HP = MaxHP;
        animatorComponent = gameObject.GetComponent<Animator>();
    }

    void Update()
    { }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (IsDead())
            SetDead();
    }

    private void SetDead()
    {
        animatorComponent.SetTrigger("IsDead");
        gameObject.GetComponent<PlayerFire>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        Invoke("GameOver", 2f);
    }

    private void GameOver() 
    {
        transform.position = startPos;
        HP = MaxHP;
        SceneManager.LoadScene(2);
    }

    private bool IsDead()
    {
        return HP <= 0;
    }
}