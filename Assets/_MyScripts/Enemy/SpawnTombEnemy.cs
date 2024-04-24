using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnTombEnemy : Spawner
{
    [SerializeField] GameObject playerGameObject;
    void Reset()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        this.Refab = Resources.Load<GameObject>("TombEnemy");
        this.spawnTime = 2.0f;
        this.spawnCount = 5;
    }
    private void Awake()
    {
        Refab.GetComponent<EnemyStatus>().heath = 30f;
        Refab.GetComponent<EnemyStatus>().strength = 7f;
        Refab.GetComponent<EnemyStatus>().speed = 3f;
        parentViewID = photonView.ViewID;
        this.Parent = gameObject;

    }
    void Update()
    {
        if (!playerGameObject) playerGameObject = GameObject.FindGameObjectWithTag("Player");
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