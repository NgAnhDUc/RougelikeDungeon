using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSourceBGM;
    [SerializeField] protected AudioSource selectAudio;


    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();
                if (_instance == null)
                {
                    Debug.LogError("GameManager instance not found!");
                }
            }
            return _instance;
        }
    }
    private void Awake()
    {
        
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        this.audioSourceBGM = GetComponent<AudioSource>();        
    }
    private void Start()
    {
        audioSourceBGM.Play();
    }

    public void SetVolumeBGM(float volume)
    {
        audioSourceBGM.volume = volume / 20;
    }
    public void PlaySelectAudio()
    {
        selectAudio.Play();
    }

}
