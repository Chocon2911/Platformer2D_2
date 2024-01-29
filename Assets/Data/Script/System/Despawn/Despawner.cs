using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner : HuyMonoBehaviour
{
    protected bool canDespawn = false;

    protected virtual void Despawn()
    {
        if (!this.canDespawn) return;
        Destroy(transform.gameObject);
        this.canDespawn = false;
        Debug.Log(transform.name + ": Despawn obj", transform.gameObject);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Despawn();
    }
}
