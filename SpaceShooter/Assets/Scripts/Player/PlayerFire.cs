using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject playerBullet;
    public Transform firePointLeft;
    public Transform firePointRight;
    public float fireRate = 1.5f;

    private float curTimeout;

    void Update()
    {
        CheckFire();
    }

    private void CheckFire()
    {
        if (Input.GetMouseButton(0))
		{
			Fire();
		}
		else
		{
			curTimeout = 100;
		}
    }

    private void Fire()
	{
		curTimeout += Time.deltaTime;

		if (curTimeout <= fireRate)
			return;
        
		curTimeout = 0;
		Instantiate(playerBullet, firePointLeft.position, Quaternion.identity);
        Instantiate(playerBullet, firePointRight.position, Quaternion.identity);
	}
}
