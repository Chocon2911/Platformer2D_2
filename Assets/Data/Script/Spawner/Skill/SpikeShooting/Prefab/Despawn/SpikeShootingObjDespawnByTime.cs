using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShootingObjDespawnByTime : DespawnByTime
{
    [SerializeField] protected SpikeShootingObjManager objManager;
    public SpikeShootingObjManager ObjManager => objManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpikeShootingObjManager();
    }

    //===========================================Load Component====================================
    protected virtual void LoadSpikeShootingObjManager()
    {
        if (this.objManager != null) return;
        this.objManager = transform.parent.GetComponent<SpikeShootingObjManager>();
        Debug.Log(transform.name + ": LoadSpikeSHootingObjManager", transform.gameObject);
    }

    //=====================================Despawn=================================================
    protected override void Despawn()
    {
        if (!this.canDespawn) return;
        SpawnerManager.Instance.SpawnSkillManager.SpikeShootingManager.Despawn(transform.parent);
        this.canDespawn = false;
        Debug.Log(transform.name + ": Despawn obj", transform.gameObject);
    }
}
