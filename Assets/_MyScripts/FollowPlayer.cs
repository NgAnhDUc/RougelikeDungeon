using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] protected Transform player;
    protected float smoothSpeed = 0.125f;
    void LateUpdate()
    {
        Vector3 pos = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed);
    }
}
