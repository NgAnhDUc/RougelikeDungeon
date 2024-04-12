using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] GameObject zombieGameObject;
    [SerializeField] GameObject playerGameObject;
    [SerializeField] protected float spawnTime = 2.0f;
    [SerializeField] protected float timer;
    [SerializeField] protected int spawnCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        zombieGameObject = GameObject.Find("Zombie");
        playerGameObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCount <= 0)
        {
            return;
        }
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            //create zombie
            Clone();
            

            // Reset timer
            timer = 0.0f;
            spawnCount--;
            
        }
    }

    public void Clone()
    {
        float randomPosX = RandomPosition();
        float randomPosY = RandomPosition();
        Vector3 playerPosition = playerGameObject.transform.position;

     
       Instantiate(zombieGameObject, new Vector3(playerPosition.x + randomPosX, playerPosition.y + randomPosY, 0), Quaternion.identity);
    }

    protected float RandomPosition ()
    {
        return Random.Range(-0.5f, 0.5f) > 0 ? Random.Range(5f, 8f) : Random.Range(-5f, -8f);
    }
}
