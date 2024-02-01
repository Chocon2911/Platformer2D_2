using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShootingObjDespawn : Despawner
{
    [SerializeField] private SpikeShootingObjManager objManager;
    public SpikeShootingObjManager ObjManager => objManager;

    [SerializeField] private SpikeShootingObjDespawnByTime objDespawnByTime;
    public SpikeShootingObjDespawnByTime ObjDespawnByTime => objDespawnByTime;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjManager();
        this.LoadObjDespawnByTime();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        float time = this.objManager.ObjSO.existTime;
        this.objDespawnByTime.DespawnTime(time);
    }

    //===========================================Load Component====================================
    protected virtual void LoadObjManager()
    {
        if (this.objManager != null) return;
        this.objManager = transform.parent.GetComponent<SpikeShootingObjManager>();
        Debug.Log(transform.name + ": LoadObjManager", transform.gameObject);
    }

    protected virtual void LoadObjDespawnByTime()
    {
        if (this.objDespawnByTime != null) return;
        this.objDespawnByTime = transform.GetComponent<SpikeShootingObjDespawnByTime>();
        Debug.Log(transform.name + ": LoadObjDespawnByTime", transform.gameObject);
    }

    //==============================================Despawn========================================
    public void SetCanDespawn(bool canDespawn)
    {
        this.canDespawn = canDespawn;
    }

    protected override void Despawn()
    {
        if (!this.canDespawn) return;
        SpawnSkillManager.Instance.SpikeShootingManager.Despawn(transform.parent);
        this.canDespawn = false;
        Debug.Log(transform.name + ": Despawn obj", transform.gameObject);
    }
}
