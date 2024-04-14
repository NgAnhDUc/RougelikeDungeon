using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PhotoLogin : MonoBehaviour
{
    [SerializeField]protected TMP_InputField inputHeroname;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = GameObject.Find("Input Hero Name");
        this.inputHeroname = gameObject.GetComponent<TMP_InputField>();
        if (this.inputHeroname.text == "")
        {
            int randomNum = Random.Range(100, 999);
            this.inputHeroname.text = "Player" + randomNum.ToString();
        }
    }
    private void Update()
    {
        string state = PhotonNetwork.NetworkClientState.ToString();
        Debug.Log(state);
    }
    public void LoginPhoton()
    {
        string heroname = this.inputHeroname.text;

        Debug.Log("Login: " + heroname);
        PhotonNetwork.LocalPlayer.NickName = heroname;
        PhotonNetwork.ConnectUsingSettings();
    }
    public void LogoutPhoton()
    {
        PhotonNetwork.Disconnect();
        Debug.Log("Logout");
    }
}
