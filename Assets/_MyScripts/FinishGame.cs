using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviourPunCallbacks
{
    [SerializeField] protected bool isFinish = false;
    
    [SerializeField] protected string nameScene = "FinishGame";
    void Update()
    {
        if (isFinish) return;
        float timer = CountDown.remainTime;
        if(timer <= 0 || GameObject.FindGameObjectWithTag("Player") == null )
        {
            if(PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.LoadLevel(nameScene);
            } else
            {
                SceneManager.LoadScene(nameScene);
            }
            isFinish = true; 
        }
    }
}
