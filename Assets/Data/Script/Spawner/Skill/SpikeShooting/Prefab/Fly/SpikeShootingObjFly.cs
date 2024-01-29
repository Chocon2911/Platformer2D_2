using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShootingObjFly : StraightFly
{
    [SerializeField] private SpikeShootingObjManager spikeShootingObjManager;
    public SpikeShootingObjManager SpikeShootingObjManager => spikeShootingObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpikeShootingObjManager();
    }

    protected override void Awake()
    {
        base.Awake();

        Rigidbody2D rb = this.spikeShootingObjManager.Rb;
        float speed = this.SpikeShootingObjManager.ObjSO.speed;
        float zRot = this.spikeShootingObjManager.gameObject.transform.rotation.eulerAngles.z;

        this.Fly(rb, speed, zRot);
    }

    protected virtual void LoadSpikeShootingObjManager()
    {
        if (this.spikeShootingObjManager != null) return;
        this.spikeShootingObjManager = transform.parent.GetComponent<SpikeShootingObjManager>();
        Debug.Log(transform.name + ": LoadSPikeShootingObjManager", transform.gameObject);
    }
}
