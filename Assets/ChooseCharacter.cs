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

    public void clickButtonRight()
    {
        if (!photonView.IsMine) return;
        this.characters[index].SetActive(false);
        index++;
        if (index >= transform.childCount) index = 0;
        this.characters[index].SetActive(true);
        SaveCharacter();
    }
    public void clickButtonLeft()
    {
        if (!photonView.IsMine) return;
        this.characters[index].SetActive(false);
        index--;
        if (index < 0) index = transform.childCount-1;
        this.characters[index].SetActive(true);
        SaveCharacter();
    }
    public void SaveCharacter()
    {
        PlayerPrefs.SetInt("ChooseChar", this.index);
    }
}
