using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class Spawner : MonoBehaviourPunCallbacks
{
    [SerializeField] protected float spawnTime = 1.0f;
    [SerializeField] protected float timer;
    [SerializeField] protected int spawnCount = 1;

    [SerializeField] protected GameObject Refab;
    [SerializeField] protected GameObject Parent;
    [SerializeField] protected Vector3 positionSpawn;
    protected GameObject Clone;

    protected virtual void SpawnRefabs()
    {
        this.Clone =Instantiate(Refab.transform,positionSpawn,Quaternion.identity).gameObject;
        if (Parent == null) return;
        this.Clone.transform.SetParent(Parent.transform);
    }
    protected virtual void SpawnRefabsPhoton()
    {
        if (!PhotonNetwork.IsConnected && !PhotonNetwork.InRoom) return;
        this.Clone =PhotonNetwork.Instantiate(Refab.name, positionSpawn, Quaternion.identity);
        if (Parent == null) return;
        this.Clone.transform.SetParent(Parent.transform);
    }
    protected virtual void SpawnRefabsInTimer()
    {
        if (this.timer < this.spawnTime) return;
            this.SpawnRefabs();
            this.timer = 0.0f;
    }
    protected virtual void Timer()
    {
        this.timer += Time.deltaTime;
    }
    protected virtual void SpawnRefabsForCount()
    {
        if (spawnCount <= 0) return;
        this.SpawnRefabs();
        spawnCount--;
    }
    protected virtual void SpawnRefabsInTimerForCount()
    {
        if (spawnCount == 0) return;
        if (this.timer < this.spawnTime) return;
        this.SpawnRefabs();
        this.timer = 0.0f;
        spawnCount--;
    }

}
