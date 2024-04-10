using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    [SerializeField] protected float speed = 0.002f;
    [SerializeField] protected GameObject heroGameObject;
    [SerializeField] protected float spawnTime = 2.0f;
    [SerializeField] protected float oldPositionX;
    [SerializeField] protected bool isFacingRight = true;

    [SerializeField] protected float timer;

    [SerializeField] protected SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        oldPositionX = transform.position.x;
        this.sprite = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        heroGameObject = GameObject.Find("Player");
        //get player GameObject and position

        Vector3 heroPosition = heroGameObject.transform.position;

        transform.position = Vector3.MoveTowards(transform.position,heroPosition,speed);


        //check object facing
        if (oldPositionX > transform.position.x)
        {
            isFacingRight = false;

        }
        else
        {
            isFacingRight = true;
        }


        //flip object
        if (isFacingRight == false)
        {
            sprite.flipX = true;
        } else
        {
            sprite.flipX = false;
        }

        //set old position to current position 
        oldPositionX = transform.position.x;
    }

}
