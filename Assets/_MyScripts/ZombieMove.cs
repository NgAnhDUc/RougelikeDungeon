using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    [SerializeField] protected float speed = 0.002f;
    [SerializeField] protected GameObject heroGameObject;
    [SerializeField] protected float spawnTime = 2.0f;

    [SerializeField] protected float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heroGameObject = GameObject.Find("Player");
        //get player GameObject and position

        Vector3 heroPosition = heroGameObject.transform.position;

        transform.position = Vector3.MoveTowards(transform.position,heroPosition,speed);

    }
}
