using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton2ReceiverDamage : MonoBehaviour
{
    Skeleton2Status skeletonStatus;
    Animator animator;
    public bool isHit = false;
    private Rigidbody2D rb;
    public float knockbackForce = 5f;

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.skeletonStatus = GetComponent<Skeleton2Status>();
        this.animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
            isHit = true;
        }

        if (skeletonStatus.heath <= 0)
        {
            animator.SetTrigger("isDead");
            transform.GetChild(0).GetComponent<EnemyTargetHero>().gameObject.SetActive(false);
            StartCoroutine(ZombieDead());
        }
    }


    protected void TakeDamage()
    {
        this.skeletonStatus.heath -= 0;
    }
    void Update()
    {
        animator.SetBool("isHit", isHit);  // Set animator parameter based on flag

        if (isHit)
        {
            // Short delay to allow animation to play
            StartCoroutine(ResetHitFlag());
        }
    }

    IEnumerator ResetHitFlag()
    {
        yield return new WaitForSeconds(0.25f);  // Adjust delay as needed
        isHit = false;

    }

    IEnumerator ZombieDead()
    {
        yield return new WaitForSeconds(0.5f);  // Adjust delay as needed
        Destroy(gameObject);
    }

}
