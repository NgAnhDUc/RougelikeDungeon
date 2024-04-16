using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner
{
    void Start()
    {
        this.Refab = Resources.Load<GameObject>("Player");
        this.Parent = gameObject;
        this.positionSpawn = transform.position;
        this.SpawnRefabs();
    }
}
