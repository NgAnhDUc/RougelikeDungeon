using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ShovelSpawn : Spawner
{
    [SerializeField] protected string bulletName;
    Animator animator;
    [SerializeField] protected AudioSource reloadGunAudio;
    [SerializeField] protected AudioSource fireGunAudio;

    private void Reset()
    {
        this.spawnTime = 3.0f;
        bulletName = "ShovelBullet";
        this.Refab = Resources.Load<GameObject>(bulletName);
    }
    private void Awake()
    {
        Refab.GetComponent<BulletStatus>().damage = 24f;
        Refab.GetComponent<BulletStatus>().reloadTime = 3f;
        this.Parent = GameObject.Find("Bullet Clone");
        parentViewID = Parent.GetComponent<PhotonView>().ViewID;
    }

    private void Start()
    {
        this.animator = GetComponent<Animator>();
        if (Refab.GetComponent<BulletStatus>() != null)
        {
            spawnTime = Refab.GetComponent<BulletStatus>().reloadTime;
        }
        else
        {
            Debug.LogError("Refab GameObject is missing BulletStatus component");
        }
    }
    private void Update()
    {
        if (transform.parent == null) return;
        this.Timer();
        this.positionSpawn = transform.position;
        if (Input.GetAxis("Fire1") == 0) return;
        if (!PhotonNetwork.InRoom)
        {
            if (this.timer < this.spawnTime) return;
            animator.SetBool("isHit", true);
            StartCoroutine(BackToHand());
            this.SpawnRefabsInTimer();
        }
        if (this.photonView.ViewID != 0 && this.photonView.IsMine)
        {
            if(this.timer < this.spawnTime) return;
            animator.SetBool("isHit", true);
            StartCoroutine(BackToHand());
            this.SpawnRefabsInTimer();
        }   
    }
    IEnumerator BackToHand()
    {
        yield return new WaitForSeconds(2.0f);  // Adjust delay as needed
        if (animator.GetBool("isHit") == true)
        {
            animator.SetBool("isHit", false);

        }
    }
    protected override void SpawnRefabsInTimer()
    {
        if (this.timer < this.spawnTime) return;
        this.fireGunAudio.Play();
        this.reloadGunAudio.PlayDelayed(spawnTime - 1f);
        base.SpawnRefabsInTimer();
    }
}
