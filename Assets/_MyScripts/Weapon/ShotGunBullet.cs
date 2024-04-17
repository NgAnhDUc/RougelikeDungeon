using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : BulletStatus
{
    private void Reset()
    {
        this.damage = 7f;
        this.reloadTime = 2.5f;
        this.quantity = 5;
    }
}
