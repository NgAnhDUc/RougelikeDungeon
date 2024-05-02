using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletStatus : MonoBehaviour
{
    public float damage = 1;
    public float reloadTime = 1;
    public int quantity = 1;

    public BulletStatusSO bulletStatus;

    private void Reset()
    {
        string path = gameObject.name;
        this.bulletStatus = Resources.Load<BulletStatusSO>(path);
    }

    private void Start()
    {
        this.damage = bulletStatus.damage;
        this.reloadTime = bulletStatus.reloadTime;
        this.quantity = bulletStatus.quantity;
    }
}