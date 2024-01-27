using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : HuyMonoBehaviour
{
    //==========================================Class==============================================
    [SerializeField] private PlayerManager playerManager;
    public PlayerManager PlayerManager => playerManager;

    //=======================================Collide Check=========================================
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected CapsuleCollider2D groundCollision;
    [SerializeField] protected CapsuleCollider2D leftWallCollision;
    [SerializeField] protected CapsuleCollider2D rightWallCollision;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerManager();
        this.LoadGroundCollision();
        this.LoadWallCollision();
        this.LoadGroundLayer();
    }

    protected override void Update()
    {
        base.Update();
        this.CheckGround();
        this.CheckWall();
    }

    //==================================LoadComponent==============================================
    protected virtual void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = transform.parent.GetComponent<PlayerManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }
    protected virtual void LoadGroundCollision()
    {
        if (this.groundCollision != null) return;
        this.groundCollision = transform.Find("Ground").GetComponent<CapsuleCollider2D>();
        Debug.Log(transform.name + ": LoadGroundCollision", transform.gameObject);
    }

    protected virtual void LoadWallCollision()
    {
        if (this.leftWallCollision != null && this.rightWallCollision != null) return;
        this.leftWallCollision = transform.Find("LeftWall").GetComponent<CapsuleCollider2D>();
        this.rightWallCollision = transform.Find("RightWall").GetComponent<CapsuleCollider2D>();
        Debug.Log(transform.name + ": LoadWallCollision", transform.gameObject);
    }

    protected virtual void LoadGroundLayer()
    {
        this.groundLayer = LayerMask.GetMask("Ground");
    }

    //======================================Update=================================================
    //==================================Collide Check==============================================
    protected virtual void CheckGround()
    {
        Vector2 playerPos_ = new Vector2(
            this.playerManager.transform.position.x,
            this.playerManager.transform.position.y);
        Vector2 pos_ = this.groundCollision.offset + playerPos_;
        Vector2 size_ = this.groundCollision.size;
        CapsuleDirection2D direction_ = this.groundCollision.direction;
        float angle_ = 0f;
        LayerMask layer_ = this.groundLayer;

        this.playerManager.PlayerSO.isGround = Physics2D.OverlapCapsule(
            pos_,
            size_,
            direction_,
            angle_,
            layer_);
    }

    protected virtual void CheckWall()
    {
        Vector2 playerPos_ = new Vector2(
            this.playerManager.transform.position.x,
            this.playerManager.transform.position.y);
        float angle_ = 0f;
        LayerMask layer_ = this.groundLayer;
        CapsuleDirection2D dir_ = this.leftWallCollision.direction;

        //======================================Left Wall Check===================================
        Vector2 leftPos_ = this.leftWallCollision.offset + playerPos_;
        Vector2 leftSize_ = this.leftWallCollision.size;

        this.playerManager.PlayerSO.isLeftWall = Physics2D.OverlapCapsule(
            leftPos_,
            leftSize_,
            dir_,
            angle_,
            layer_);

        //=====================================Right Wall Check===================================
        Vector2 rightPos_ = this.rightWallCollision.offset + playerPos_;
        Vector2 rightSize_ = this.rightWallCollision.size;

        this.playerManager.PlayerSO.isRightWall = Physics2D.OverlapCapsule(
            rightPos_,
            rightSize_,
            dir_,
            angle_,
            layer_);
    }
}
