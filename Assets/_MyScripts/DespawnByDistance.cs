using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DespawnByDistance : MonoBehaviour
{
    public float destroyDistance = 5;  // Distance threshold for destruction
    public GameObject target;        // Reference point (usually the player)

    private void Awake()
    {
        target =GameObject.FindGameObjectsWithTag("Player")[0];
    }
    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance > destroyDistance)
            {
                Destroy(gameObject);
            }
        }
    }

}
