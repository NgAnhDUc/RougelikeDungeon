using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : BulletStatus
{
    private void Reset()
    {
        this.damage = 7f;
        this.reloadTime = 0.25f;
        this.quantity = 5;
    }
}
