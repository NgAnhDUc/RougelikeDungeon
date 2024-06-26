using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UIElements;

public class MachineGunSpawnBullet : Spawner
{
    [SerializeField] protected string bulletName;
    [SerializeField] protected AudioSource reloadGunAudio;
    [SerializeField] protected AudioSource fireGunAudio;
    [SerializeField] protected new Collider2D collider;
    private void Reset()
    {
        bulletName = "MachineGunBullet";
        this.Refab = Resources.Load<GameObject>(bulletName);
        
    }

    private void Awake()
    {
        Refab.GetComponent<BulletStatus>().damage = 2f;
        Refab.GetComponent<BulletStatus>().reloadTime = 0.25f;
        this.Parent = GameObject.Find("Bullet Clone");
        parentViewID = Parent.GetComponent<PhotonView>().ViewID;
        
    }

    private void Start()
    {
        if (Refab.GetComponent<BulletStatus>() != null)
        {
            spawnTime = Refab.GetComponent<BulletStatus>().reloadTime;
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
            this.SpawnRefabsInTimer();
        }
        if (this.photonView.ViewID != 0 && this.photonView.IsMine)
            this.SpawnRefabsInTimer();

    }
    protected override void SpawnRefabsInTimer()
    {
        if (this.timer < this.spawnTime) return;
        this.fireGunAudio.Play();
        this.reloadGunAudio.PlayDelayed(spawnTime - 0.5f);
        base.SpawnRefabsInTimer();
    }
}
