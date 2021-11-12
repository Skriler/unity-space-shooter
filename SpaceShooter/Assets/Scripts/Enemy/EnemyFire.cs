using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject enemyBullet;
    public Transform firePoint;

    public float fireTimeFirst = 1f;
    public float fireInterval = 1.5f;

    void Start() 
    {
        InvokeRepeating("Fire", fireTimeFirst, fireInterval);
    }

    private void Fire()
	{
        GameObject player = GameObject.Find("Player");

        if (player == null)
            return;

        GameObject bullet = Instantiate(enemyBullet, firePoint.position, Quaternion.identity);

		Vector2 direction = player.transform.position - bullet.transform.position;

        bullet.GetComponent<EnemyBullet>().SetDirection(direction);
	}
}
