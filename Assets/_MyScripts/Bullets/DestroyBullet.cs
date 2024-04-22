using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
