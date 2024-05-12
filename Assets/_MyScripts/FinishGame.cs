using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviourPunCallbacks
{
    [SerializeField] protected string nameScene = "FinishGame";
    void Update()
    {
        float timer = CountDown.remainTime;
        if(timer <= 0 || GameObject.FindGameObjectWithTag("Player") == null )
        {
            Debug.Log("Finish");
            if(PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.LoadLevel(nameScene);
            } else
            {
                SceneManager.LoadScene(nameScene);
            }

        }
    }
}
