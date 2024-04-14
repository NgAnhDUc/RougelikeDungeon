using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] protected float speed = 10f;
    public Rigidbody2D rb;
    public bool shoot=false;

    private void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = transform.up * speed;

        if (shoot==true) return;
        Vector2 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        shoot = true;
        Vector3 norTar = (worldPos - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle - 90);
        transform.rotation = rotation;
    }
}
