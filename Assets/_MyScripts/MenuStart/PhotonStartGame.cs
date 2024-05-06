using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PhotonStartGame : MonoBehaviourPunCallbacks
{
    [SerializeField] string nameScene = "MainMap2";
    public void StartGamePhoton()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.LoadLevel(nameScene);
        }
    }
    public void StarGameOffline()
    {
        SceneManager.LoadScene(nameScene);
    }
}
