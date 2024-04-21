using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class SpawnPlayerCard :Spawner
{
    void Start()
    {
        this.Refab = Resources.Load<GameObject>("Player Card");
        this.Parent = GameObject.Find("Grid");
    }
    protected void AddPlayerToGrid()
    {

        if (this.photonView.ViewID == 0) return; this.SpawnRefabs();
        Transform heroName = this.Clone.transform.Find("Player Name");
        TMP_Text heroNameText = heroName.GetComponent<TMP_Text>();
        heroNameText.text = this.photonView.Owner.NickName;
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
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        AddPlayerToGrid();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        AddPlayerToGrid();
    }
}
