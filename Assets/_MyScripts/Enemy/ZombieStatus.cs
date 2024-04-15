using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStatus : MonoBehaviour
{
    [SerializeField] protected float heath = 10f;
    [SerializeField] protected float strength = 10f;
    [SerializeField] protected float speed = 10f;
    [SerializeField] protected int damageTake = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }

        if (heath <= 0)
        {
            Destroy(gameObject);
        }
    }
    

    protected void TakeDamage()
    {
        this.heath -= damageTake;
    } 
}
