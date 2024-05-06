using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;

public class CameraFollowPlayer : MonoBehaviourPun
{
    [SerializeField] protected Transform player;
    public GameObject[] players;

    protected float smoothSpeed = 0.125f;
    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
        this.player = players[0].transform;
        if (!PhotonNetwork.IsConnected && !PhotonNetwork.InRoom) return;
        foreach (GameObject player in players)
        {
            if (PhotonView.Get(player).IsMine)
            {
                this.player = player.transform;
                break;
            }
        }
    }

    private void FixedUpdate()
    {
        if(players.Count<GameObject>() == 0)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
            this.player = players[0].transform;
        }
    }

    void LateUpdate()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
    }
}
