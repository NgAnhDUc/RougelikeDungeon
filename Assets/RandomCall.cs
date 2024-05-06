using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RandomCall : MonoBehaviourPun,IPunInstantiateMagicCallback
{
    GameObject parent;
    object[] instantiationData;
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        this.instantiationData = info.photonView.InstantiationData;
        int viewID =(int) this.instantiationData[0];
        this.parent = PhotonView.Find(viewID).gameObject;
        string word = (string)instantiationData[1];
        this.transform.SetParent(parent.transform);
    }
}
