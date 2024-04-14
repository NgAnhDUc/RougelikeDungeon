using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoSetPlayerCard : MonoBehaviour
{
    [SerializeField]public TMP_Text playerCard_Name;
    [SerializeField]public TMP_Text playerCard_Ready;
    public string heroName ="hero";
    void Start()
    {
        transform.localScale = new Vector3(1, 1, 1);
        GameObject playerCard_NameGO =transform.GetChild(2).gameObject;
        GameObject playerCard_ReadyGO =transform.GetChild(3).gameObject;

        this.playerCard_Name = playerCard_NameGO.GetComponent<TMP_Text>();
        this.playerCard_Ready = playerCard_ReadyGO.GetComponent<TMP_Text>();

        this.playerCard_Name.text = "Hero";
        this.playerCard_Ready.text = "Ready";
    }
    /*private void FixedUpdate()
    {
        playerCard_Name.text = heroName;
    }*/
}
