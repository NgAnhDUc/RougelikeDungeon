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

    public List<Sprite> avatarList;
    public List<Sprite> weaponList;
    public List<Sprite> statusList;
    public SpriteRenderer avatarSprite;
    public SpriteRenderer weaponSprite;
    public SpriteRenderer statusSprite;

    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    Player player;

    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        playerProperties["CharaterIndex"] = 0;
        SetSpriteChar((int)playerProperties["CharaterIndex"]);
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
            Debug.Log(player.NickName + "-UpdateChar:" + changedProps["CharaterIndex"]);
            UpdatePlayerItem(player, (int)changedProps["CharaterIndex"]);
        }
    }
    public void UpdatePlayerItem(Player player, int index)
    {
            SetSpriteChar(index);
            
    }
    public void SetSpriteChar(int index)
    {
        if(player == PhotonNetwork.LocalPlayer) {
            PlayerPrefs.SetInt("ChooseChar",(int) playerProperties["CharaterIndex"]);
        }
        avatarSprite.sprite = avatarList[index];
        weaponSprite.sprite = weaponList[index];
        statusSprite.sprite = statusList[index];
    }
}

