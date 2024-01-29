using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class SpikeShootingObjManager : HuyMonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] private BoxCollider2D bodyCollide;
    public BoxCollider2D BodyCollide => bodyCollide;

    [SerializeField] private SpikeShootingObjFly objFly;
    public SpikeShootingObjFly ObjFly => objFly;

    [SerializeField] private SpikeShootingObjDespawnByTime objDespawnByTime;
    public SpikeShootingObjDespawnByTime ObjDespawnByTime => objDespawnByTime;

    [SerializeField] private SpikeShootingObjSO objSO;
    public SpikeShootingObjSO ObjSO => objSO;

    protected override void OnEnable()
    {
        base.OnEnable();
        Rigidbody2D rb = this.rb;
        float speed = this.objSO.speed;
        float zRot = transform.rotation.eulerAngles.z;
        this.objFly.Fly(rb, speed, zRot);

        float time = this.objSO.existTime;
        this.objDespawnByTime.DespawnTime(time);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjFly();
        this.LoadObjDespawnByTime();
        this.LoadRigidbody();
        this.LoadBodyCollide();
    }

    //======================================Load Component=========================================
    protected virtual void LoadObjFly()
    {
        if (this.objFly != null) return;
        this.objFly = transform.Find("Fly").GetComponent<SpikeShootingObjFly>();
        Debug.Log(transform.name + ": LoadSpikeShootingObjFly", transform.gameObject);
    }

    protected virtual void LoadObjDespawnByTime()
    {
        if (this.objDespawnByTime != null) return;
        this.objDespawnByTime = transform.Find("Despawn").GetComponent<SpikeShootingObjDespawnByTime>();
        Debug.Log(transform.name + ": LoadObjDespawnByTime", transform.gameObject);
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
        this.bodyCollide = transform.GetComponent<BoxCollider2D>();
        this.bodyCollide.isTrigger = true;
        Debug.Log(transform.name + ": LoadBodyCollide", transform.gameObject);
    }
}
