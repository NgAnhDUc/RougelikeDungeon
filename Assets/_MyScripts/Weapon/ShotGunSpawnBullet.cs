using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class ShotGunSpawnBullet : Spawner
{
    [SerializeField] protected string bulletName;
    [SerializeField] protected AudioSource reloadShotGunAudio;
    [SerializeField] protected AudioSource fireShotGunAudio;
    private void Reset()
    {
        bulletName = "ShotGunBullet";
        this.Refab = Resources.Load<GameObject>(bulletName);
    }

    private void Awake()
    {
        Refab.GetComponent<BulletStatus>().damage = 3.5f;
        Refab.GetComponent<BulletStatus>().reloadTime = 2f;
        Refab.GetComponent<BulletStatus>().quantity = 5;
        this.Parent = GameObject.Find("Bullet Clone");
        parentViewID = Parent.GetComponent<PhotonView>().ViewID;
    }

    private void Start()
    {
        if (Refab.GetComponent<BulletStatus>() != null)
        {
            spawnTime = Refab.GetComponent<BulletStatus>().reloadTime;
            spawnQuantity = Refab.GetComponent<BulletStatus>().quantity;
        }
        else
        {
            Debug.LogError("Refab GameObject is missing BulletStatus component");
        }
    }
    private void Update()
    {
        if (transform.parent == null) return;
        this.Timer();
        this.positionSpawn = transform.position;
        if (Input.GetAxis("Fire1") == 0) return;
        if (!PhotonNetwork.InRoom)
        {
            this.SpawnRefabsInTimerToQuantity();
        }
        if (this.photonView.ViewID != 0 && this.photonView.IsMine)
            this.SpawnRefabsInTimerToQuantity();

    }
    protected override void SpawnRefabsInTimerToQuantity()
    {
        if (this.timer < this.spawnTime) return;
        this.fireShotGunAudio.Play();
        this.reloadShotGunAudio.PlayDelayed(1.75f);
        base.SpawnRefabsInTimerToQuantity();
    }
}
