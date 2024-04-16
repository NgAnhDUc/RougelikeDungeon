using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] protected Transform myCamera;
    [SerializeField] protected Vector3 posMenuPlay;
    [SerializeField] protected Vector3 posMenuHeroName;
    [SerializeField] protected Vector3 posMenuCreateRoom;
    [SerializeField] protected Vector3 posMenuRoom;
    [SerializeField] protected Vector3 posMenuLoading;
    [SerializeField] protected TMP_InputField inputRoomID;
    void Awake()
    {
        this.myCamera = GameObject.Find("Main Camera").transform;

        Transform tranformMenuPlay = GameObject.Find("Menu Play").transform;
        this.posMenuPlay =new Vector3( tranformMenuPlay.position.x,tranformMenuPlay.position.y,-10);

        Transform tranformMenuHeroName = GameObject.Find("Menu Hero Name").transform;
        this.posMenuHeroName = new Vector3(tranformMenuHeroName.position.x, tranformMenuHeroName.position.y, -10);

        Transform tranformMenuCreateRoom = GameObject.Find("Menu Create Room").transform;
        this.posMenuCreateRoom = new Vector3(tranformMenuCreateRoom.position.x, tranformMenuCreateRoom.position.y, -10);

        Transform tranformMenuRoom = GameObject.Find("Menu Room").transform;
        this.posMenuRoom = new Vector3(tranformMenuRoom.position.x, tranformMenuRoom.position.y, -10);
        
        Transform tranformMenuLoading = GameObject.Find("Menu Loading").transform;
        this.posMenuLoading = new Vector3(tranformMenuLoading.position.x, tranformMenuLoading.position.y, -10);
    }
    public void clickToMenuHeroName()
    {
        this.myCamera.position = this.posMenuHeroName;
    }
    public void clickToMenuPlay()
    {
        this.myCamera.position = this.posMenuPlay;
    }
    public void clickToMenuLoading()
    {
        this.myCamera.position = this.posMenuLoading;
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        this.myCamera.position = this.posMenuCreateRoom;
    }
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        this.myCamera.position = this.posMenuRoom;
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        this.myCamera.position = this.posMenuRoom;
    }
    public override void OnLeftRoom()
    {
        base.OnLeftRoom();

    }
}
