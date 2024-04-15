using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PhotonStartGame : MonoBehaviourPunCallbacks
{
    public void StartGamePhoton()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.LoadLevel("PhotonGame");
        }
    }
}
