using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShootingManager : Spawner
{
    protected override void Start()
    {
        base.Start();
        this.Spawn("BlueBullet", Vector2.zero, transform.rotation);
    }
}
