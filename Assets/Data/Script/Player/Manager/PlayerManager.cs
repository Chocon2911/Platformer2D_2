using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEditor.Recorder.AOV;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : HuyMonoBehaviour
{
    [SerializeField] protected CapsuleCollider2D bodyCollide;
    public CapsuleCollider2D BodyCollide => bodyCollide;

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    //==========================================Class==============================================
    [SerializeField] private PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    [SerializeField] protected PlayerAnimationManager playerAnimation;
    public PlayerAnimationManager PlayerAnimation => playerAnimation;

    [SerializeField] protected PlayerMovementManager playerMovement;
    public PlayerMovementManager PlayerMovement => playerMovement;

    [SerializeField] private PlayerInputManager playerInput;
    public PlayerInputManager PlayerInput => playerInput;

    [SerializeField] protected PlayerSO playerSO;
    public PlayerSO PlayerSO => playerSO;

    [SerializeField] protected Transform playerCollisionTrans;
    public Transform PlayerCollisionTrans => playerCollisionTrans;

    //======================================Instance===============================================
    public static PlayerManager Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBodyCollide();
        this.LoadRigidbody();
        this.LoadPlayerCtrl();
        this.LoadPlayerAnimation();
        this.LoadPlayerMovement();
        this.LoadPlayerInput();
        this.LoadPlayerCollisionTrans();
    }

    protected virtual void LoadBodyCollide()
    {
        if (this.bodyCollide != null) return;
        this.bodyCollide = transform.GetComponent<CapsuleCollider2D>();
        this.bodyCollide.isTrigger = false;
        Debug.Log(transform.name + ": LoadBodyCollide", transform.gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        this.rb.isKinematic = false;
        this.rb.freezeRotation = true;
        Debug.Log(transform.name + ": LoadRigidBody", transform.gameObject);
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", transform.gameObject);
    }

    protected virtual void LoadPlayerInput()
    {
        if (this.playerInput != null) return;
        this.playerInput = transform.Find("Input").GetComponent<PlayerInputManager>();
        Debug.Log(transform.name + ": LoadPlayerInput", transform.gameObject);
    }

    protected virtual void LoadPlayerAnimation()
    {
        if (this.playerAnimation != null) return;
        this.playerAnimation = transform.Find("Animation").GetComponent<PlayerAnimationManager>();
        Debug.Log(transform.name + ": LoadPlayerAnimation", transform.gameObject);
    }

    protected virtual void LoadPlayerMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = transform.Find("Movement").GetComponent<PlayerMovementManager>();
        Debug.Log(transform.name + ": LoadPlayerMovement", transform.gameObject);
    }

    protected virtual void LoadPlayerCollisionTrans()
    {
        if (this.playerCollisionTrans != null) return;
        this.playerCollisionTrans = transform.Find("Collision");
        Debug.Log(transform.name + ": LoadPlayerCollisionTrans", transform.gameObject);
    }
}