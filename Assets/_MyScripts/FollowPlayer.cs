using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class FollowPlayer : MonoBehaviourPunCallbacks
{
    [SerializeField] protected Transform player;
    protected float smoothSpeed = 0.125f;
    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (PhotonView.Get(player).IsMine)
            {
                this.player = player.transform;
                break;
            }
        }
    }
    void LateUpdate()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
    }
}
