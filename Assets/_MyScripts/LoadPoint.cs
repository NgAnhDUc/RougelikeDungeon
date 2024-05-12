using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadPoint : MonoBehaviour
{
    [SerializeField] protected TMP_Text point;
    private void Start()
    {
        GameObject label = GameObject.Find("Point Label");
        point = label.GetComponent<TMP_Text>();
        point.text = PlayerPrefs.GetInt("point")*10 + " Points";
    }
}
