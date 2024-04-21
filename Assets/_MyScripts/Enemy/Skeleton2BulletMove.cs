using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton2BulletMove : MonoBehaviour
{
    [SerializeField] protected float speed;
    public Rigidbody2D rb;


    private void Awake()
    {
        speed = 1f;
    }
    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (transform.IsDestroyed()) return;
        transform.RotateAround(transform.parent.position, Vector3.forward, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
