using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieReceiverDamage : MonoBehaviour
{
    ZombieStatus zombieStatus;
    Animator animator;
    public bool isHit = false;
    private Rigidbody2D rb;
    public float knockbackForce = 5f;

    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.zombieStatus = GetComponent<ZombieStatus>();
        this.animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
            isHit = true;
        }

        if (zombieStatus.heath <= 0)
        {
            animator.SetTrigger("isDead");
            transform.GetChild(0).GetComponent<EnemyTargetHero>().gameObject.SetActive( false);
            StartCoroutine(ZombieDead());
        }
    }


    protected void TakeDamage()
    {
        this.zombieStatus.heath -= 0;
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
