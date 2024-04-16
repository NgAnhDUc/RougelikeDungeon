using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    protected Vector3 posMenuPlay;
    protected Vector3 posMenuHeroName;
    protected Vector3 posMenuCreateRoom;
    protected Vector3 posMenuRoom;

    void Awake()
    {
        Transform tranformMenuPlay = GameObject.Find("Menu Play").transform;
        this.posMenuPlay = tranformMenuPlay.position;

        Transform tranformMenuHeroName = GameObject.Find("Menu Hero Name").transform;
        this.posMenuHeroName = tranformMenuHeroName.position;

        Transform tranformMenuCreateRoom = GameObject.Find("Menu Create Room").transform;
        this.posMenuCreateRoom = tranformMenuCreateRoom.position;

        Transform tranformMenuRoom = GameObject.Find("Menu Room").transform;
        this.posMenuRoom = tranformMenuRoom.position;
    }
}
