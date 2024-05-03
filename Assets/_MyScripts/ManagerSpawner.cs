using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawner : Spawner
{
    // Start is called before the first frame update
    public WaveSO ware1;
    public int wareindex = 1;
    public GameObject spawnerZombie;
    public GameObject spawnerSke;
    private void Reset()
    {
        this.spawnerZombie = Resources.Load<GameObject>("Spawn Zombie");
        this.spawnerSke = Resources.Load<GameObject>("Spawn Skeleton");
        this.Parent = gameObject;
        this.positionSpawn = transform.position;
    }
    private void Start()
    {
        SpawnerZombie();
    }
    protected void SpawnerZombie()
    {
        this.Refab = spawnerZombie;
        SpawnRefabs();
    }
    protected void SpawnerSke()
    {
        this.Refab = spawnerZombie;

    }
}
