using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetHero : MonoBehaviour
{
    [SerializeField] protected float speed = 0.03f;
    [SerializeField] protected GameObject player;
    [SerializeField] protected SpriteRenderer sprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") player = collision.gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);

        if(transform.position.x > player.transform.position.x)
        {
            sprite.flipX = true; 
        } else
        {
            sprite.flipX = false;
        }
    }
}
