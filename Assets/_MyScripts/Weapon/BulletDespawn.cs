using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{

    [SerializeField] protected float destroyTime;
    [SerializeField] protected float timer;
    private void Start()
    {
        timer = 0;
        destroyTime = 3f;
    }
    void Update()
    {
        Timer();
        if(timer > destroyTime)
        {
            this.DestroyObject(gameObject);
        }
    }

    protected virtual void Timer()
    {
        this.timer += Time.deltaTime;
    }
}
