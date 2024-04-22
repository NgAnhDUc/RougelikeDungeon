using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReceiverDamage : MonoBehaviour
{
    [SerializeField] protected EnemyStatus enemyStatus;
    Animator animator;
    public bool isHit = false;
    private Rigidbody2D rb;
    

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        enemyStatus = GetComponent<EnemyStatus>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            float damage = collision.gameObject.GetComponent<BulletStatus>().damage;
            TakeDamage(damage);
            isHit = true;
        }

        if (enemyStatus.heath <= 0)
        {
            animator.SetTrigger("isDead");
            transform.GetChild(0).GetComponent<EnemyTargetHero>().gameObject.SetActive(false);
            StartCoroutine(ZombieDead());
        }
    }


    protected void TakeDamage(float damage)
    {
        this.enemyStatus.heath -= damage;
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
