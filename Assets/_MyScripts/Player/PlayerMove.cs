using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerMove : MonoBehaviour
{

    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float moveX = 0f;
    [SerializeField] protected float moveY = 0f;

    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected Animator animator;
    [SerializeField] protected PhotonView photonView;

    [SerializeField] public bool canMove = true;


    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    private void Start()
    {
        this.sprite = transform.GetComponent<SpriteRenderer>();
        this.animator = transform.GetComponent<Animator>();
    }
    void Update()
    {
        if (!PhotonNetwork.InRoom)
        {
            MovementPlayer();
            setParameterAnimation();
        }
        if (!photonView.IsMine)return;
        MovementPlayer();
        setParameterAnimation();
    }
    
    protected void MovementPlayer()
    {
        if (!canMove) return;
        this.moveX = Input.GetAxis("Horizontal");
        this.moveY = Input.GetAxis("Vertical");
        if (moveX == 0 && moveY == 0) return;

        float moveMagnitude = Mathf.Sqrt(moveX * moveX + moveY * moveY);
        Vector3 moveVector3 = new Vector3(moveX / moveMagnitude, moveY / moveMagnitude, 0);

        transform.Translate(moveVector3 * this.speed * Time.deltaTime);

        FlipPlayer();
    }
    
    protected void setParameterAnimation()
    {
        float sumAnim = moveX + moveY;

        if (sumAnim == 0)
        {
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
        }
    }

    protected void FlipPlayer()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        if(transform.position.x > worldPos.x)
        {
            sprite.flipX = true;
        }else
        {
            sprite.flipX = false;
        }
    } 
}
