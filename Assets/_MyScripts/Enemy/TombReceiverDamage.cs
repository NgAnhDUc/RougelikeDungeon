using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombReceiverDamage : Spawner
{
    [SerializeField] protected EnemyStatus enemyStatus;
    Animator animator;
    public bool isHit = false;
    private Rigidbody2D rb;

    
    private void Reset()
    {
        this.Refab = Resources.Load<GameObject>("Zombie2");
        this.spawnCount = 1;
        this.spawnQuantity = 3;
    }

    private void Start()
    {
        
        enemyStatus = GetComponent<EnemyStatus>();
        this.rb = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
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
        Parent = transform.parent.gameObject;
        if (!Parent) {
            Debug.Log("not found parent");
            return;
        } 
        parentViewID = Parent.GetPhotonView().ViewID;
        animator.SetBool("isHit", isHit);  // Set animator parameter based on flag

        if (isHit)
        {
            // Short delay to allow animation to play
            StartCoroutine(ResetHitFlag());
        }

        positionSpawn = transform.position;
        if(enemyStatus.heath <= 0)
        {
            Debug.Log("Spawn child tomb");
            SpawnRefabsForCountToQuantity();
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
        PlayerPrefs.SetInt("point", PlayerPrefs.GetInt("point") + 1);
        Debug.Log(PlayerPrefs.GetInt("point"));
        Destroy(gameObject);
    }
}
