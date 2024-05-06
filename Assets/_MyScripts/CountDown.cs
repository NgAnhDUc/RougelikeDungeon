using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI timer;
    float remainTime = 75;


    private void Awake()
    {
        timer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if(remainTime > 0)
        {
            remainTime -= Time.deltaTime;
            if(remainTime <= 10) timer.color = Color.red;
        } else
        {
            remainTime = 0;
        }
          
        int minute = Mathf.FloorToInt(remainTime / 60);
        int second = Mathf.FloorToInt(remainTime % 60);
        timer.text = string.Format("{0:00}:{1:00}",minute,second);
    }
}
