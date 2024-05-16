using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTargetHero : MonoBehaviour
{
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected GameObject player;
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected Transform enemy;
    [SerializeField] protected float maxDistance = 10f;


    // Start is called before the first frame update
    void Start()
    {
        enemy = transform.parent;
        sprite = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!player) return;

        Vector3 direction = player.transform.position - enemy.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, direction, direction.magnitude);

        if (hit.collider != null)
        {
            direction = Vector2.Reflect(direction, hit.normal);
        }

        enemy.transform.position -= direction.normalized * speed * Time.deltaTime;


        if (enemy.position.x > player.transform.position.x)
        {
            sprite.flipX = true; 
        } else
        {
            sprite.flipX = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
        } else
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }



}
