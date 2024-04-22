using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class Spawner : MonoBehaviourPunCallbacks
{
    [SerializeField] protected float spawnTime = 1.0f;
    [SerializeField] protected float timer;
    [SerializeField] protected int spawnCount = 1;
    [SerializeField] protected int spawnQuantity = 1;

    [SerializeField] protected GameObject Refab;
    [SerializeField] protected GameObject Parent;
    [SerializeField] protected Vector3 positionSpawn;
    [SerializeField] protected int parentViewID;
    protected GameObject Clone;
    public virtual void Reset()
    {
        parentViewID = photonView.ViewID;
    }
    protected virtual void SpawnRefabs()
    {
        if (PhotonNetwork.IsConnected)
        {
            /*          this.Clone = PhotonNetwork.Instantiate(Refab.name, positionSpawn, Quaternion.identity);
            */
            string word = "example";
            object[] myCustomInitData = new object[3];
            myCustomInitData[0] = parentViewID;
            myCustomInitData[1] = word;
            
            this.Clone = PhotonNetwork.Instantiate(Refab.name, positionSpawn, Quaternion.identity, 0, myCustomInitData);
            Debug.Log("SpawnPrefabInPhoton");
        }
        else
        {
            this.Clone = Instantiate(Refab.transform, positionSpawn, Quaternion.identity).gameObject;
            Debug.Log("SpawnPrefabInOffline");
            if (Parent == null) return;
            this.Clone.transform.SetParent(Parent.transform);
        }
        

    }
    protected virtual void Spawn()
    {
         this.Clone = Instantiate(Refab.transform, positionSpawn, Quaternion.identity).gameObject;
        if (Parent == null) return;
        this.Clone.transform.SetParent(Parent.transform);
    }
    protected virtual void SpawnRefabsInTimer()
    {
        if (this.timer < this.spawnTime) return;
            this.SpawnRefabs();
            this.timer = 0.0f;
    }

    protected virtual void SpawnRefabsInTimerToQuantity()
    {
        if (this.timer < this.spawnTime) return;
        for (int i = spawnQuantity; i > 0; i--)
        {
            this.SpawnRefabs();
        }
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
