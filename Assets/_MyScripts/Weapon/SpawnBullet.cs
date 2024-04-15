using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : Spawner
{
    private void Reset()
    {
        this.Refab = Resources.Load<GameObject>("Bullet 3");
        this.Parent = GameObject.Find("Bullet Clone");
    }
    private void Update()
    {
        this.Timer();
        this.positionSpawn = transform.position;
        if (Input.GetAxis("Fire1") == 0) return;
        this.SpawnRefabsInTimer();
    }
}
