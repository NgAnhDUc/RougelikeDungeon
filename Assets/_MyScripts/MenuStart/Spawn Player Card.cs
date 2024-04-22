using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class SpawnPlayerCard :MonoBehaviourPunCallbacks
{
    public List<PlayerItem> playerItemsList =new List<PlayerItem>();
    public PlayerItem playerItemRefabs;
    public Transform playerItemParent;
    
    protected void UpdatePlayerList()
    {
        foreach(PlayerItem item in playerItemsList)
        {
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();
        if (PhotonNetwork.CurrentRoom == null) return;
        foreach(KeyValuePair<int,Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPlayerItem = Instantiate(playerItemRefabs, playerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);
            playerItemsList.Add(newPlayerItem);
            if(player.Value == PhotonNetwork.LocalPlayer)
            {
                newPlayerItem.ApplyLocalChange();
            }
        }
    }

    //Pun CallBacks
    public override void OnCreatedRoom()
    {
        UpdatePlayerList();
    }
    public override void OnJoinedRoom()
    {
        UpdatePlayerList();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }
}
