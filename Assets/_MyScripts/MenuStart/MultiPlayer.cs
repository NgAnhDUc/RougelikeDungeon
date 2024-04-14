using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MultiPlayer : MonoBehaviour
{
    [SerializeField] GameObject cameraPos;
    private void Start()
    {
        this.cameraPos = GameObject.Find("Main Camera");
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
}
