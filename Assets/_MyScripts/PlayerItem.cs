using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    public TMP_Text playerName;
    public GameObject buttonLeft;
    public GameObject buttonRight;
    public Transform charParent;
    public List<GameObject> charList;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    Player player;
    private void Awake()
    {
        for(int i = 0; i < charParent.childCount; i++)
        {
            charList.Add(charParent.GetChild(i).gameObject);
        }
    }
    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        playerProperties["CharaterIndex"] = 0;
        SetActionChar((int)playerProperties["CharaterIndex"]);
    }
    public void ApplyLocalChange()
    {
        buttonLeft.SetActive(true);
        buttonRight.SetActive(true);
    }

    public void OnClickLeftArrow()
    {
        playerProperties["CharaterIndex"] =(int) playerProperties["CharaterIndex"] - 1;
        if((int)playerProperties["CharaterIndex"] < 0)
        {
            playerProperties["CharaterIndex"] = 3;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    public void OnClickRightArrow()
    {
        playerProperties["CharaterIndex"] = (int)playerProperties["CharaterIndex"] + 1;
        if ((int)playerProperties["CharaterIndex"] > 3)
        {
            playerProperties["CharaterIndex"] = 0;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }
    public void UpdatePlayerItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("CharaterIndex"))
        {
            SetActionChar((int)playerProperties["CharaterIndex"]);
            playerProperties["CharaterIndex"] = (int)playerProperties["CharaterIndex"];
            PlayerPrefs.SetInt("ChooseChar", (int)playerProperties["CharaterIndex"]);
        }
    }
    public void SetActionChar(int index)
    {
        foreach(GameObject item in charList)
        {
            item.SetActive(false);
            if(item == charList[index])
            {
                item.SetActive(true);
            }
        }
    }
}
