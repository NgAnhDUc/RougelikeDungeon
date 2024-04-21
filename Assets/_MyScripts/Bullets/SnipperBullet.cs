using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipperBullet : BulletStatus
{
    private void Reset()
    {
        this.damage = 5f;
        this.reloadTime = 1f;
    }
}
