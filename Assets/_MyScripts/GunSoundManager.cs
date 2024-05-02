using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSoundManager : MonoBehaviour
{
    public AudioSource machineGunLoadAudio;
    public AudioSource machineGunShootAudio;
    public AudioSource shotGunLoadAudio;
    public AudioSource shotGunShootAudio;
    public AudioSource shovelLoadAudio;
    public AudioSource shovelShootAudio;
    public AudioSource sniperGunLoadAudio;
    public AudioSource sniperGunShootAudio;

    private void Awake()
    {
        machineGunLoadAudio.playOnAwake = false;
        machineGunShootAudio.playOnAwake = false;
        shotGunLoadAudio.playOnAwake = false;
        shotGunShootAudio.playOnAwake = false;
        shovelLoadAudio.playOnAwake = false;
        shovelShootAudio.playOnAwake = false;
        sniperGunLoadAudio.playOnAwake = false;
        sniperGunShootAudio.playOnAwake = false;
    }

    public void PlayMachineGunSound()
    {
        machineGunShootAudio.Play();
    }
    public void PlayShotGunSound()
    {
        shotGunShootAudio.Play();
    }
    public void PlayShovelSound()
    {
        shotGunShootAudio.Play();
    }
    public void PlaySniperSound()
    {
        sniperGunShootAudio.Play();
    }
}
