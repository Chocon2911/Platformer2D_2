using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class SpikeShootingObjManager : HuyMonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] private CapsuleCollider2D bodyCollide;
    public CapsuleCollider2D BodyCollide => bodyCollide;

    [SerializeField] private SpikeShootingObjFly objFly;
    public SpikeShootingObjFly ObjFly => objFly;

    [SerializeField] private SpikeShootingObjSO objSO;
    public SpikeShootingObjSO ObjSO => objSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpikeShootingObjFly();
        this.LoadRigidbody();
        this.LoadBodyCollide();
    }

    //======================================Load Component=========================================
    protected virtual void LoadSpikeShootingObjFly()
    {
        if (this.objFly != null) return;
        this.objFly = transform.Find("Fly").GetComponent<SpikeShootingObjFly>();
        Debug.Log(transform.name + ": LoadSpikeShootingObjFly", transform.gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        this.rb.isKinematic = true;
        this.rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        this.rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
    }

    protected virtual void LoadBodyCollide()
    {
        if (this.bodyCollide != null) return;
        this.bodyCollide = transform.GetComponent<CapsuleCollider2D>();
        this.bodyCollide.isTrigger = true;
        Debug.Log(transform.name + ": LoadBodyCollide", transform.gameObject);
    }
}
