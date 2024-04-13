using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] protected float speed = 0.05f;
    [SerializeField] protected float moveX = 0f;
    [SerializeField] protected float moveY = 0f;

    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected SpriteRenderer spriteWeapon;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform weapon;

    private Vector3 previousMousePosition;
    public float rotationSpeed = 1000.0f;
    public LayerMask SolidObject;
    private Rigidbody2D rb;
    private void Start()
    {
        this.sprite = transform.GetComponent<SpriteRenderer>();
        this.animator = transform.GetComponent<Animator>();

        this.weapon = transform.GetChild(0);
        this.spriteWeapon = weapon.GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        this.moveX = Input.GetAxis("Horizontal");
        this.moveY = Input.GetAxis("Vertical");
        float sumAnim = moveX + moveY;
        Vector3 moveVector3 = new Vector3(moveX, moveY, 0);

        transform.Translate(moveVector3 * this.speed);

        if (moveX < 0)
        {
            sprite.flipX = true;
            spriteWeapon.flipX = true;
        }
        if (moveX > 0)
        {
            sprite.flipX = false;
            spriteWeapon.flipX = false;
        }
        if (sumAnim == 0)
        {
            animator.SetBool("isRun", false);
        }
        else
        {
            animator.SetBool("isRun", true);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 normal = hit.normal;

            weapon.Rotate(Vector3.up * normal.x * rotationSpeed * Time.deltaTime);
        }

    }
}
