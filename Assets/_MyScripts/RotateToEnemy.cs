using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RotateToEnemy : MonoBehaviour
{
    [SerializeField] protected GameObject closestEnemy;
    [SerializeField] protected GameObject player;
    [SerializeField] protected SpriteRenderer playerSprite;
    [SerializeField] protected SpriteRenderer weaponSprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        this.playerSprite = player.GetComponent<SpriteRenderer>();
        weaponSprite = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float minDistance = Mathf.Infinity;

        foreach (GameObject clone in GameObject.FindGameObjectsWithTag("Zombie"))
        {
            float distance = Vector3.Distance(transform.position, clone.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = clone;
            }
            
        }

        Vector3 norTar = (closestEnemy.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        Quaternion rotation = new Quaternion();

        if (player.transform.position.x > closestEnemy.transform.position.x)
        {
            playerSprite.flipX = true;
            weaponSprite.flipX = true;
            rotation.eulerAngles = new Vector3(0, 0, angle -180 );
        } else
        {
            playerSprite.flipX=false;
            weaponSprite.flipX=false; 
            rotation.eulerAngles = new Vector3(0, 0, angle);
        }

        transform.rotation = rotation;



    }
}
