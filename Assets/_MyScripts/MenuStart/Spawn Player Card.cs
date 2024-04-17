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
        for (int i = Parent.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Parent.transform.GetChild(i).gameObject);
        }
        foreach (KeyValuePair<int, Player> playerEntry in PhotonNetwork.CurrentRoom.Players)
        {
            Player player = playerEntry.Value;
            this.Spawn();
            Transform heroName = this.Clone.transform.GetChild(2);
            TMP_Text heroNameText = heroName.GetComponent<TMP_Text>();
            heroNameText.text = player.NickName;
        }
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
