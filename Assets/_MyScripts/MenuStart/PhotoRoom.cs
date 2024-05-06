using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class PhotoRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] protected TMP_Text textRoomID;
    [SerializeField] protected TMP_Text textPlayerCount;
    [SerializeField] protected TMP_InputField inputRoomID;

    [SerializeField] protected List<Player> listPlayer;
    [SerializeField] public List<string> listPlayerName;
    
    void Start()
    {
        GameObject textRoomIDgameObject = GameObject.Find("Text Room ID");
        this.textRoomID = textRoomIDgameObject.GetComponent<TMP_Text>();
        
        GameObject textPlayerCountgameObject = GameObject.Find("Text Player Count");
        this.textPlayerCount = textPlayerCountgameObject.GetComponent<TMP_Text>();

        GameObject inputRoomIDgameObject = GameObject.Find("Input Room ID");
        this.inputRoomID = inputRoomIDgameObject.GetComponent<TMP_InputField>();

        listPlayer = new List<Player>();
    }
    public void HostRoom()
    {
        int ranNumber = Random.Range(10000, 99999);
        string roomID = ranNumber.ToString();
        PhotonNetwork.CreateRoom(roomID,new RoomOptions() {MaxPlayers =4,BroadcastPropsChangeToAll=true});
        Debug.Log("Create Room: " + roomID);
    }
    public void JoinRoom()
    {
        if (this.inputRoomID.text == "") return;
        string roomID = this.inputRoomID.text;
        Debug.Log(roomID);
        PhotonNetwork.JoinRoom(roomID);
    }
    public void LeftRoom()
    {
        PhotonNetwork.LeaveRoom(true);
    }
    protected void SetPlayerCount()
    {
        this.textPlayerCount.text =PhotonNetwork.CurrentRoom.PlayerCount.ToString()+"/4";
    }
    private void SetRoomIDText()
    {
        this.textRoomID.text = "Room ID: " + PhotonNetwork.CurrentRoom.Name;
    }
    private void GetPlayerInPhoton()
    {
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            listPlayer.Clear();
            listPlayerName.Clear();
            foreach (KeyValuePair<int, Player> playerEntry in PhotonNetwork.CurrentRoom.Players)
            {
                Player player = playerEntry.Value;
                listPlayer.Add(player);
                listPlayerName.Add(player.NickName);
            }
            Debug.Log(listPlayer.Count);
        }
    }
    //PunCallBacks
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log(newPlayer.NickName);
        SetPlayerCount();
        GetPlayerInPhoton();
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        SetPlayerCount();
        GetPlayerInPhoton();
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        SetRoomIDText();
        SetPlayerCount();
        GetPlayerInPhoton();
        Debug.Log("Join Room: " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        SetRoomIDText();
        SetPlayerCount();
        GetPlayerInPhoton();
    }
}
