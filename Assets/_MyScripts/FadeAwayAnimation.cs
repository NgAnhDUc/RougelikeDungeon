using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeAwayAnimation : MonoBehaviour
{
    public float fadeTime;
    public TMP_Text text;
    public float alpha;
    public float fadePerSecond;
    // Start is called before the first frame update
    void Start()
    {
        fadeTime = 2;
        GameObject textGO = GameObject.Find("WaveText");
        text = textGO.GetComponent<TMP_Text>();
        fadePerSecond = 1/fadeTime;
        alpha = text.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeTime > 0)
        {
            alpha -= fadePerSecond * Time.deltaTime;
            text.color = new Color(text.color.r,text.color.g,text.color.b,alpha);
            fadeTime -= Time.deltaTime;
        }
    }
}
