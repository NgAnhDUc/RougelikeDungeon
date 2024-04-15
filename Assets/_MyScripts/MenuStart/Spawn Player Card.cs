using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class SpawnPlayerCard : MonoBehaviourPunCallbacks
{
    [SerializeField] protected GameObject playerCard;
    [SerializeField] protected GameObject grid;

    void Start()
    {
        this.playerCard = Resources.Load<GameObject>("Player Card");
        this.grid = GameObject.Find("Grid");
    }
    
    protected void AddPlayerToGrid()
    {
        List<string> temp = new List<string>();
        foreach (KeyValuePair<int, Player> playerEntry in PhotonNetwork.CurrentRoom.Players)
        {
            Player player = playerEntry.Value;
            temp.Add(player.NickName);
        }
        for (int i = grid.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(grid.transform.GetChild(i).gameObject);
        }
        foreach (string player in temp)
        {
            GameObject clone = Instantiate(playerCard);
            clone.transform.SetParent(grid.transform);
            Transform heroName = clone.transform.GetChild(2);
            TMP_Text heroNameText = heroName.GetComponent<TMP_Text>();
            heroNameText.text = player;
        }
    }
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
