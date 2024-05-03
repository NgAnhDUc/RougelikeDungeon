using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "BulletStatusSO")]

public class BulletStatusSO : ScriptableObject
{
    public float damage;
    public float reloadTime;
    public int quantity;
}
