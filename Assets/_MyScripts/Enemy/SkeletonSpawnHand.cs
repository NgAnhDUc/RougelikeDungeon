using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonSpawnHand : Spawner
{
    private void Reset()
    {
        this.Refab = Resources.Load<GameObject>("Skeleton2Hand");
        this.Parent = gameObject;
        this.parentViewID = photonView.ViewID;
    }

    
    void Start()
    {
        this.positionSpawn = transform.position;

        SpawnRefabs(); 
    }

}
