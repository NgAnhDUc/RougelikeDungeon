using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Skeleton2SpawnBullet : Spawner
{
    [SerializeField] protected string bulletName;
    private void Reset()
    {
        bulletName = "Skeleton2Bullet";
        this.Refab = Resources.Load<GameObject>(bulletName);
        this.Parent = gameObject;
    }
    private void Awake()
    {
        this.parentViewID = photonView.ViewID;
    }
    private void Start()
    {
        spawnTime = 0.5f;
        spawnCount = 5; 
    }
    private void Update()
    {
        if (transform.parent == null) return;
        this.Timer();
        this.positionSpawn = new Vector3(transform.position.x + 2f ,transform.position.y,transform.position.z);
        if (!PhotonNetwork.InRoom)
        {
            this.SpawnRefabsInTimerForCount();
        }
        if (this.photonView.ViewID != 0 && this.photonView.IsMine)
            this.SpawnRefabsInTimerForCount();

    }
}
