using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBullet : BulletStatus
{
    private void Reset()
    {
        this.damage = 1.5f;
        this.reloadTime = 0.25f;
    }
}
