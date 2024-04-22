using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChooseCharacter : MonoBehaviourPun
{
    public List<GameObject> characters;
    int index = 0;
    private void Awake()
    {
        for(int i =0; i < transform.childCount; i++)
        {
            GameObject charater = transform.GetChild(i).gameObject;
            this.characters.Add(charater);
            charater.SetActive(false);
        }
        this.characters[index].SetActive(true);
        SaveCharacter();
    }
    private void Update()
    {
        SetPlayerCard();
    }

    public void clickButtonRight()
    {
        if (!photonView.IsMine) return;
        index++;
        SaveCharacter();
    }
    public void clickButtonLeft()
    {
        if (!photonView.IsMine) return;
        index--;
        SaveCharacter();
    }
    public void SetPlayerCard()
    {
        if (index >= transform.childCount) index = 0;
        if (index < 0) index = transform.childCount - 1;
        foreach (GameObject item in characters)
        {
            item.SetActive(false);
            if(item == this.characters[index])
            {
                item.SetActive(true);
            }
        }
    }
    public void SaveCharacter()
    {
        PlayerPrefs.SetInt("ChooseChar", this.index);
    }
}
