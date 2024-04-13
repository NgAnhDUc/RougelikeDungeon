using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    [SerializeField] protected Transform bullet;
    [SerializeField] protected float checkShoot;
    [SerializeField] protected float spawnTime = 1.0f;
    [SerializeField] protected float timer;


    private void Reset()
    {
        bullet = transform.GetChild(0);
        bullet.gameObject.SetActive(false);
    }
    private void Update()
    {
        
        timer += Time.deltaTime;
        checkShoot = Input.GetAxis("Fire1");
        if (checkShoot == 0) return;

        if (timer >= spawnTime)
        {
            //create zombie
            Clone();
            // Reset timer
            timer = 0.0f;
        }

    }
    protected void Clone()
    {
        Transform bulletClone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        bulletClone.gameObject.SetActive(true);
        
    }
}
