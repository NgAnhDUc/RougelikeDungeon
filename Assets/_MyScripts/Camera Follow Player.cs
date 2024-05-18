using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;

public class CameraFollowPlayer : MonoBehaviourPun
{
    [SerializeField] protected Transform player;
    public GameObject[] players;
    public bool isFollow;
    public int myPlayerIndex;

    protected float smoothSpeed = 0.125f;
    private void Start()
    {
        isFollow = true;
        players = GameObject.FindGameObjectsWithTag("Player");
        
        this.player = players[0].transform;

        if (!PhotonNetwork.IsConnected && !PhotonNetwork.InRoom) return;
        foreach (GameObject playerItem in players)
        {
            if (PhotonView.Get(player).IsMine)
            {
                this.player = playerItem.transform;
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i] == player)
                    {
                        myPlayerIndex = i;
                    }
                }
                break;

            }
        }
    }

    private void FixedUpdate()
    {
        if (isFollow) return;
        if (!PhotonNetwork.IsConnected) return;
        players = GameObject.FindGameObjectsWithTag("Player");
        this.player = players[0].transform;
        isFollow = true;        
    }

    void LateUpdate()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
    }
}
