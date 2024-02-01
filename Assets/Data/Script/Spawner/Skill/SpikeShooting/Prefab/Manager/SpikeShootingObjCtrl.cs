using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeShootingObjCtrl : HuyMonoBehaviour
{
    [SerializeField] private SpikeShootingObjManager objManager;
    public SpikeShootingObjManager ObjManager => objManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjManager();
    }

    protected virtual void LoadObjManager()
    {
        if (this.objManager != null) return;
        this.objManager = transform.GetComponent<SpikeShootingObjManager>();
        Debug.Log(transform.name + ": LoadObjManager", transform.gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            this.CollideGround();
        }
    }

    //===========================================Collide other=====================================
    protected virtual void CollideGround()
    {
        this.objManager.ObjDespawn.SetCanDespawn(true);
        Debug.Log(transform.name + ": Collide Ground", transform.gameObject);
    }
}
