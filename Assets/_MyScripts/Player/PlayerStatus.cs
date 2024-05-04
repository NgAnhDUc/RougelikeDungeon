using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerStatus : MonoBehaviourPunCallbacks
{
    [SerializeField] protected Animator animator;
    [SerializeField] public float heath =20f;
    [SerializeField] public float mana =10f;
    [SerializeField] public float stamina =10f;
    [SerializeField] public float strength =10f;
    [SerializeField] public float speed =10f;
    [SerializeField] public string role;

    [SerializeField] protected TMP_Text heroName;
    private void Start()
    {
        animator = transform.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        SetTextPlayerNamePhoton();
    }
    private void Update()
    {
        if (heath > 0) return;
        animator.SetBool("isDead", true);
        gameObject.tag = "Finish";
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        gameObject.GetComponent<PlayerMove>().canMove = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        
        if (collision.gameObject.tag == "Enemy")
        {
            float damage = collision.gameObject.GetComponent<EnemyStatus>().strength;
            heath -= damage;
        } 

        if (collision.gameObject.tag == "EnemyBullet")
        {
            float damage = collision.gameObject.GetComponent<BulletStatus>().damage;
            heath -= damage;
        }
    }


    protected void SetTextPlayerNamePhoton()
    {
        this.heroName.text = "offline";
        if (this.photonView.ViewID == 0) return;
        this.heroName.text = this.photonView.Owner.NickName;
    }
}
