using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SkeletonSpawnBullet : Spawner
{
    [SerializeField] protected string bulletName;
    private void Reset()
    {
        bulletName = "SkeletonBullet";
        this.Refab = Resources.Load<GameObject>(bulletName);
        this.Parent = GameObject.Find("Bullet Clone");
    }

    private void Start()
    {
            spawnTime = 3;
    }
    private void Update()
    {
        if (transform.parent == null) return;
        this.Timer();
        this.positionSpawn = transform.position;
        if (!PhotonNetwork.InRoom)
        {
            this.SpawnRefabsInTimer();
        }
        if (this.photonView.ViewID != 0 && this.photonView.IsMine)
            this.SpawnRefabsInTimer();

    }
}
