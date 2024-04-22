using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class AutoSetPlayerCard : MonoBehaviourPun
{
    TMP_Text heroNameText;
    private void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
        Transform heroName = transform.Find("Player Name");
        this.heroNameText = heroName.GetComponent<TMP_Text>();
        
    }
    private void Update()
    {
        if (this.photonView.ViewID == 0) return;
        this.heroNameText.text = this.photonView.Owner.NickName;
    }
}
