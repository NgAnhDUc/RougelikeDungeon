using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class MultiPlayer : MonoBehaviour
{
    [SerializeField] GameObject cameraPos;
    [SerializeField] protected TMP_InputField inputRoomID;

    private void Start()
    {
        this.cameraPos = GameObject.Find("Main Camera");

        GameObject inputRoomIDgameObject = GameObject.Find("Input Room ID");
        this.inputRoomID = inputRoomIDgameObject.GetComponent<TMP_InputField>();
    }
    public void clickMultiPlayer()
    {
        cameraPos.transform.position = new Vector3(0, 0, -10);
    }
    public void clickBack()
    {
        cameraPos.transform.position = new Vector3(-20, 0, -10);
    }
    public void clickGo()
    {
        cameraPos.transform.position = new Vector3(20, 0, -10);
    }
    public void clickRoom()
    {
        cameraPos.transform.position = new Vector3(40, 0, -10);
    }
    public void clickJoinRoom()
    {
        if (this.inputRoomID.text == "") return;
        cameraPos.transform.position = new Vector3(40, 0, -10);

    }
}
