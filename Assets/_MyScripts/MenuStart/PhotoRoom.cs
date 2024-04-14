using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;


public class PhotoRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject cameraPos;
    [SerializeField] protected TMP_Text textRoomID;
    [SerializeField] protected TMP_Text textPlayerCount;
    [SerializeField] protected TMP_InputField inputRoomID;
    void Start()
    {
        this.cameraPos = GameObject.Find("Main Camera");

        GameObject textRoomIDgameObject = GameObject.Find("Text Room ID");
        this.textRoomID = textRoomIDgameObject.GetComponent<TMP_Text>();
        
        GameObject textPlayerCountgameObject = GameObject.Find("Text Player Count");
        this.textPlayerCount = textPlayerCountgameObject.GetComponent<TMP_Text>();

        GameObject inputRoomIDgameObject = GameObject.Find("Input Room ID");
        this.inputRoomID = inputRoomIDgameObject.GetComponent<TMP_InputField>();
    }
    private void Update()
    {
        this.textPlayerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "/4";
    }
    public void HostRoom()
    {
        int ranNumber = Random.Range(10000, 99999);
        string roomID = ranNumber.ToString();
        PhotonNetwork.CreateRoom(roomID);        
    }
    public void JoinRoom()
    {
        if (this.inputRoomID.text == "") return;
        string roomID = this.inputRoomID.text;
        PhotonNetwork.JoinRoom(roomID);
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("Create Room: " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        this.textRoomID.text = "Room ID: " + PhotonNetwork.CurrentRoom.Name;
        Debug.Log("Join Room: " + PhotonNetwork.CurrentRoom.Name);
        this.textPlayerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "/4";
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("PlayerJoin");
        this.textPlayerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "/4";
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        this.textPlayerCount.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString() + "/4";

    }

}
