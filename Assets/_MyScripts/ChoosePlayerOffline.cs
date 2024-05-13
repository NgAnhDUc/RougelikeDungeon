using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayerOffline : MonoBehaviour
{
    public int charInt = 0; 
    public void ClickChoosePlayerOffline()
    {
        PlayerPrefs.SetInt("ChooseChar", charInt);
        Debug.Log("ChooseChar =" + charInt);
    }
}
