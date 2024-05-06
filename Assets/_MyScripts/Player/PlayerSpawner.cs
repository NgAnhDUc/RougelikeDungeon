using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : Spawner
{
    public List<GameObject> prefabsList;
    public int index =1;
    private void Awake()
    {
        GameObject[] prefabsArray = Resources.LoadAll<GameObject>("Players");
        foreach (GameObject gameObject in prefabsArray)
        {
            prefabsList.Add(gameObject);
        }
        if (PhotonNetwork.IsConnected)
        {
            this.index = PlayerPrefs.GetInt("ChooseChar");
        }
        this.Refab = prefabsList[this.index];
        this.Parent = gameObject;
        this.positionSpawn = transform.position;
    }
    void Start()
    {
        this.parentViewID = photonView.ViewID;
        this.SpawnRefabs();   
    }
    
}
