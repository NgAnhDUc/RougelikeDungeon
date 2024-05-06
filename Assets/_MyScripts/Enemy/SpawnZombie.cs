using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnZombie : Spawner
{
    [SerializeField] GameObject playerGameObject;
    public float spawnTimeSpawn = 2.0f;
    public int quantitySpawn = 5;
    void Reset()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        this.Refab = Resources.Load<GameObject>("Zombie");
    }
    private void Awake()
    {
        this.spawnTime = spawnTimeSpawn;
        this.spawnCount = quantitySpawn;
        this.Parent = gameObject;
        this.parentViewID = photonView.ViewID;
    }
    void Update()
    {
        if(!playerGameObject) playerGameObject = GameObject.FindGameObjectWithTag("Player");
        this.Timer();
        RandomPosition();
        SpawnRefabsInTimerForCount();
    }
    protected void RandomPosition()
    {
        float random = Random.Range(-0.5f, 0.5f) > 0 ? Random.Range(5f, 8f) : Random.Range(-5f, -8f);
        Vector3 playerPosition = playerGameObject.transform.position;
        this.positionSpawn = new Vector3(playerPosition.x + random, playerPosition.y + random, 0);
    }
}
