using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float heath = 1;
    public float strength = 1;
    public float speed = 1;
    public EnemyStatusSO enemyStatus;
    private void Start()
    {
        string path = "/" + gameObject.name;
        this.enemyStatus = Resources.Load<EnemyStatusSO>(path);
        this.heath = enemyStatus.heath;
        this.strength = enemyStatus.strength;
        this.speed = enemyStatus.speed;
    }
}
