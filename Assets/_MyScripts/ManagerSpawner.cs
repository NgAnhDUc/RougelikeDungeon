using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerSpawner : Spawner
{
    // Start is called before the first frame update
    public int wareindex = 4;
    public GameObject spawnerZombie;
    public GameObject spawnerZombie2;
    public GameObject spawnerSke;
    public GameObject spawnerSke2;
    public GameObject spawnerTomb;
    public bool isSpawner = false;

    GameObject waveTextGO;
    TextMeshPro waveText;
    private void Reset()
    {
        this.spawnerZombie = Resources.Load<GameObject>("Spawn Zombie");
        this.spawnerZombie2 = Resources.Load<GameObject>("Spawn Zombie2");
        this.spawnerSke = Resources.Load<GameObject>("Spawn Skeleton");
        this.spawnerSke2 = Resources.Load<GameObject>("Spawn Skeleton2");
        this.spawnerTomb = Resources.Load<GameObject>("Spawn TombEnemy");
    }

    private void Awake()
    {
        this.Parent = gameObject;
        this.positionSpawn = transform.position;
        this.parentViewID = photonView.ViewID;

        waveTextGO = GameObject.Find("WaveText");
        waveText = waveTextGO.GetComponent<TextMeshPro>();

        waveTextGO.SetActive(false);

        
        
    }

    private void Update()
    {
        if (isSpawner == true) return;
            
        switch (wareindex)
        {
            case 1:
                Ware1();
                break;
            case 2:
                Ware2();
                break;
            case 3:
                Ware3();
                break;
            case 4:
                Ware4();
                break;
            case 5:
                Ware5();
                break;
        }
        isSpawner = true;

    }
    protected void SpawnerZombie()
    {
        this.Refab = spawnerZombie;
        this.Refab.GetComponent<SpawnZombie>().spawnTimeSpawn = 0.1f;
        this.Refab.GetComponent<SpawnZombie>().quantitySpawn = 5;
        SpawnRefabs();
    }
    protected void SpawnerSke()
    {
        this.Refab = spawnerSke;
        this.Refab.GetComponent<SpawnSkeleton>().spawnTimeSpawn = 0.1f;
        this.Refab.GetComponent<SpawnSkeleton>().quantitySpawn = 5;
        SpawnRefabs();
    }
    protected void SpawnerZombie2()
    {
        this.Refab = spawnerZombie2;
        this.Refab.GetComponent<SpawnZombie2>().spawnTimeSpawn = 0.1f;
        this.Refab.GetComponent<SpawnZombie2>().quantitySpawn = 5;
        SpawnRefabs();
    }
    protected void SpawnerSke2()
    {
        this.Refab = spawnerSke2;
        this.Refab.GetComponent<SpawnSkeleton2>().spawnTimeSpawn = 0.1f;
        this.Refab.GetComponent<SpawnSkeleton2>().quantitySpawn = 5;
        SpawnRefabs();
    }
    protected void SpawnerTomb()
    {
        this.Refab = spawnerTomb;
        this.Refab.GetComponent<SpawnTombEnemy>().spawnTimeSpawn = 0.1f;
        this.Refab.GetComponent<SpawnTombEnemy>().quantitySpawn = 5;
        SpawnRefabs();
    }

    protected void Ware1()
    {
        SpawnerZombie();
        Invoke("EndWare", 15);
    }
    protected void Ware2()
    {
        SpawnerZombie2();
        Invoke("EndWare", 15);
    }
    protected void Ware3()
    {
        SpawnerSke();
        Invoke("EndWare", 15);
    }
    protected void Ware4()
    {
        SpawnerSke2();
        Invoke("EndWare", 15);
    }
    protected void Ware5()
    {
        SpawnerTomb();
        Invoke("EndWare", 15);
    }

    protected void EndWare()
    {
        waveTextGO.SetActive(true);

        Invoke("EndWaveText", 3f);

        wareindex++;
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
            isSpawner = false;
        }
    }

    protected void EndWaveText()
    {
        waveTextGO.SetActive(false);
    }
}
