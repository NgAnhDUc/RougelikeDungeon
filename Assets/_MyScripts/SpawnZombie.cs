using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField] GameObject playerGameObject;
    [SerializeField] protected float spawnTime = 2.0f;
    [SerializeField] protected float timer;
    [SerializeField] protected int spawnCount = 1;
    [SerializeField] protected GameObject zombieRefab ;

    void Start()
    {
        
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        this.zombieRefab = Resources.Load<GameObject>("Zombie");
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
        GameObject Zomgroup = GameObject.Find("ZombieGroup");
        float randomPosX = RandomPosition();
        float randomPosY = RandomPosition();
        Vector3 playerPosition = playerGameObject.transform.position;
        GameObject clone = Instantiate(zombieRefab, new Vector3(playerPosition.x + randomPosX, playerPosition.y + randomPosY, 0), Quaternion.identity);
        /*clone.transform.SetParent(Zomgroup.transform);*/
    }

    protected float RandomPosition ()
    {
        return Random.Range(-0.5f, 0.5f) > 0 ? Random.Range(5f, 8f) : Random.Range(-5f, -8f);
    }
}
