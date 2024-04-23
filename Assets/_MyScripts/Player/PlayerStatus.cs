using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerStatus : MonoBehaviourPunCallbacks
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected float heath =20f;
    [SerializeField] protected float mana =10f;
    [SerializeField] protected float stamina =10f;
    [SerializeField] protected float strength =10f;
    [SerializeField] protected float speed =10f;
    [SerializeField] protected string role;
    [SerializeField] protected int damageTake = 3;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            float damage = collision.gameObject.GetComponent<BulletStatus>().damage;
            heath -= damage;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            InvokeRepeating("OnTakeDamage", 0f, 1f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CancelInvoke();
    }

    protected void OnTakeDamage()
    {
        this.heath -= damageTake;
    }
    protected void SetTextPlayerNamePhoton()
    {
        this.heroName.text = "offline";
        if (this.photonView.ViewID == 0) return;
        this.heroName.text = this.photonView.Owner.NickName;
    }
}
