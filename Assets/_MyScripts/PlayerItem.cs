using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerItem : MonoBehaviour
{
    public TMP_Text playerName;
    public GameObject buttonLeft;
    public GameObject buttonRight;
    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
    }
    public void ApplyLocalChange()
    {
        buttonLeft.SetActive(true);
        buttonRight.SetActive(true);
    }
}
