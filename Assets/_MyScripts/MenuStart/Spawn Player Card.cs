using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class SpawnPlayerCard :Spawner
{
    public List<GameObject> posList;
    int index = 0;
    void Reset()
    {
        this.Refab = Resources.Load<GameObject>("Player Card");

        GameObject pos1 = GameObject.Find("Pos1");
        this.posList.Add(pos1);
        GameObject pos2 = GameObject.Find("Pos2");
        this.posList.Add(pos2);
        GameObject pos3 = GameObject.Find("Pos3");
        this.posList.Add(pos3);
        GameObject pos4 = GameObject.Find("Pos4");
        this.posList.Add(pos4);
    }
    protected void AddPlayerToGrid()
    {
        this.index = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        this.Parent = posList[index];
        this.positionSpawn = posList[index].transform.position;
        if (this.photonView.ViewID == 0) return;
        this.SpawnRefabs();
        Transform heroName = this.Clone.transform.Find("Player Name");
        TMP_Text heroNameText = heroName.GetComponent<TMP_Text>();
        heroNameText.text = PhotonNetwork.LocalPlayer.NickName;
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
