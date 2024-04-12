using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] protected float speed = 3f;
    [SerializeField] protected float moveX = 0f;
    [SerializeField] protected float moveY = 0f;

    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected Animator animator;

    private Vector3 previousMousePosition;
    public float rotationSpeed = 1000.0f;
    
    private void Start()
    {
        this.sprite = transform.GetComponent<SpriteRenderer>();
        this.animator = transform.GetComponent<Animator>();
    }
    void Update()
    {
        this.moveX = Input.GetAxis("Horizontal");
        this.moveY = Input.GetAxis("Vertical");
        float sumAnim = moveX + moveY;
        Vector3 moveVector3 = new Vector3(moveX, moveY, 0);
        
        transform.Translate(moveVector3 * this.speed);

        if (sumAnim == 0)
        {
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
        }

        FlipPlayer();

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
