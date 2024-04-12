using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] protected float speed = 3f;
    [SerializeField] protected float moveX = 0f;
    [SerializeField] protected float moveY = 0f;

    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected SpriteRenderer spriteWeapon;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform weapon;

    private void Start()
    {
        this.sprite = transform.GetComponent<SpriteRenderer>();
        this.animator = transform.GetComponent<Animator>();

        this.weapon = transform.GetChild(0);
        this.spriteWeapon = weapon.GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        MovementPlayer();
        setParameterAnimation();
    }
    
    protected void MovementPlayer()
    {
        this.moveX = Input.GetAxis("Horizontal");
        this.moveY = Input.GetAxis("Vertical");
        Vector3 moveVector3 = new Vector3(moveX, moveY, 0);

        transform.Translate(moveVector3 * this.speed);
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
}
