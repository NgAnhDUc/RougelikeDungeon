using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;


public class PhotoRoom : MonoBehaviour
{
    [SerializeField] protected TMP_Text textRoomID;
    [SerializeField] protected TMP_InputField inputRoomID;
    void Start()
    {
        GameObject textRoomIDgameObject = GameObject.Find("Text Room ID");
        this.textRoomID = textRoomIDgameObject.GetComponent<TMP_Text>();

        GameObject inputRoomIDgameObject = GameObject.Find("Input Room ID");
        this.inputRoomID = inputRoomIDgameObject.GetComponent<TMP_InputField>();
    }
    public void HostRoom()
    {
        int ranNumber = Random.Range(10000, 99999);
        string roomID = ranNumber.ToString();
        PhotonNetwork.CreateRoom(roomID);
        this.textRoomID.text ="Room ID: " +roomID;
        Debug.Log("Create Room: " + roomID);
    }
    public void JoinRoom()
    {
        if (this.inputRoomID.text == "") return;
        string roomID = this.inputRoomID.text;
        PhotonNetwork.JoinRoom(roomID);
        this.textRoomID.text ="Room ID: " +roomID;
        Debug.Log("Join Room: " + roomID);
    }
}
