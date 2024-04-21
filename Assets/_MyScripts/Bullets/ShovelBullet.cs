using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelBullet : BulletStatus
{
    private void Reset()
    {
        this.damage = 7f;
        this.reloadTime = 3f;
        this.quantity = 5;
    }
}
