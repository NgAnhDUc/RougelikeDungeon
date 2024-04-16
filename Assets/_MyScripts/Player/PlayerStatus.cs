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

    [SerializeField] protected PhotonView photonView;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    private void Start()
    {
        animator = transform.GetComponent<Animator>();
        SetTextPlayerNamePhoton(PhotonNetwork.LocalPlayer.NickName);
    }

    private void Update()
    {
        if (heath >= 0) return;
        
        animator.SetBool("isDead", true);
        gameObject.tag = "Finish";
        photonView.RPC("SetTextPlayerNamePhoton", RpcTarget.All,PhotonNetwork.LocalPlayer.NickName;);
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
    protected void SetTextPlayerNamePhoton(string textName)
    {
        if (!PhotonNetwork.IsConnected && !PhotonNetwork.InRoom) return;
        if (!photonView.IsMine) return;
        heroName.text = textName;
    }
}
