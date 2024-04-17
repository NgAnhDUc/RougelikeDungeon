using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;   

public class sliderBGM : MonoBehaviour
{
    Slider slider;

    private void Awake()
    {
        this.slider = GetComponent<Slider>();
    }
    public void SetVolumeBGM()
    {
        float volume = this.slider.value;
        SoundManager.Instance.SetVolumeBGM(volume);
    }
}
