using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class SpawnPlayerCard :Spawner
{
    public List<Transform> posList;
    int index = 0;
    void Awake()
    {
        this.Refab = Resources.Load<GameObject>("Player Card");
        this.parentViewID = photonView.ViewID;
        for( int i = 0; i < transform.childCount; i++)
        {
            this.posList.Add(transform.GetChild(i));
        }
    }
    protected void AddPlayerToGrid()
    {
        index = PhotonNetwork.CurrentRoom.PlayerCount;
        this.Parent = gameObject;
        this.positionSpawn = this.posList[index-1].position;
        if (this.photonView.ViewID == 0) return;
        
        this.SpawnRefabs();
    }

    //Pun CallBacks
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        AddPlayerToGrid();
    }
}
