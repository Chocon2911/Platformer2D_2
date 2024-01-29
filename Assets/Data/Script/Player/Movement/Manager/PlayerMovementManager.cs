using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementManager : HuyMonoBehaviour
{
    //=========================================Player Class========================================
    [SerializeField] private PlayerManager playerManager;
    public PlayerManager PlayerManager => playerManager;

    //==========================================Render=============================================
    [SerializeField] protected TrailRenderer dashRender;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerManager();
        this.LoadDashRender();
    }

    protected override void Start()
    {
        base.Start();
        this.dashRender.emitting = false;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Dash();
        if (!this.playerManager.PlayerSO.isDash)
        {
            this.Move();
            this.Jump();
        }
    }

    //=========================================Load Component=======================================
    protected virtual void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = transform.GetComponentInParent<PlayerManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }

    protected virtual void LoadDashRender()
    {
        if (this.dashRender != null) return;
        this.dashRender = transform.GetComponent<TrailRenderer>();
        Debug.Log(transform.name + ": LoadDashRender", transform.gameObject);
    }

    //====================================Fixed Update===================================
    //======================================Move=========================================
    protected virtual void Move()
    {
        float moveInput = this.playerManager.PlayerInput.MoveInput;
        float accel = this.PlayerManager.PlayerSO.accel;
        float deAccel = this.playerManager.PlayerSO.deAccel;
        float maxSpeed = this.playerManager.PlayerSO.maxSpeed;
        float currVelocity =this.playerManager.Rb.velocity.x;

        if (currVelocity > 0.1 || currVelocity < -0.1 || moveInput == 1 || moveInput == -1)
        {
            float speedDif = maxSpeed * moveInput - currVelocity;
            float speed = (moveInput != 0) ? speedDif * accel : speedDif * deAccel;
            this.playerManager.Rb.AddForce(speed * Vector2.right * Time.fixedDeltaTime);
        }
        else
        {
            this.playerManager.Rb.velocity = new Vector2(0, this.playerManager.Rb.velocity.y);
        }
    }

    //======================================Jump=========================================
    protected virtual void Jump()
    {
        float jumpInput = this.playerManager.PlayerInput.JumpInput;
        bool isDash = this.playerManager.PlayerSO.isDash;
        bool isJump = this.playerManager.PlayerSO.isJump;
        bool isGround = this.playerManager.PlayerSO.isGround;

        //when on Ground
        if (isGround)
        {
            float baseGravity = this.playerManager.PlayerSO.baseGravityScale;
            float currJumpSpeed = this.playerManager.Rb.velocity.y;

            //player is not jumping and no gravity
            if (currJumpSpeed < 0.1f)
            {
                this.playerManager.PlayerSO.isJump = false;
                this.SetGravityScale(1);
            }

            if (jumpInput == 1 && !isJump) //if player press jump, do jump
            {
                this.DoJump();
                this.playerManager.PlayerSO.isJump = true;
            }
            else if (isJump)
            {
                this.SetGravityScale(baseGravity);
            }
        }

        //when in air
        else
        {
            float currYVelocity = this.playerManager.Rb.velocity.y;
            float minJumpSpeedAtPeak = this.playerManager.PlayerSO.airJumpBorder;
            float baseGravity = this.playerManager.PlayerSO.baseGravityScale;
            float airGravity = this.playerManager.PlayerSO.airGravity;

            //control when player presses and holds jump
            if (jumpInput == 1 && isJump)
            {
                //set gravity low when player at peak of the jump
                if (currYVelocity > -minJumpSpeedAtPeak && currYVelocity < minJumpSpeedAtPeak)
                {
                    this.SetGravityScale(airGravity);
                }
                //set gravity at base when player does not reach peak of the jump
                else
                {
                    this.SetGravityScale(baseGravity);
                }
            }

            //when player isn't jumping or holding jump
            else
            {
                //if player doesn't hold jump then make a high gravity to cut jump
                if (currYVelocity > 0 && isJump)
                {
                    float currXVelocity = this.playerManager.Rb.velocity.x;
                    this.playerManager.Rb.velocity = new Vector2 (currXVelocity, 0);   
                    this.playerManager.PlayerSO.isJump = false;
                }
                else
                {
                    this.SetGravityScale(baseGravity);
                }
            }
        }
    }

    protected virtual void DoJump()
    {
        float jumpHeight = this.playerManager.PlayerSO.jumpHeight;
        float currVelocity = this.playerManager.Rb.velocity.y;

        //when player falling, give additional current speed to jumpHeight
        if (currVelocity < 0)
        {
            jumpHeight -= currVelocity;
        }

        this.playerManager.Rb.AddForce(jumpHeight * Vector2.up, ForceMode2D.Impulse);
    }

    //======================================Dash=======================================
    protected virtual void Dash()
    {
        float dashInput = this.playerManager.PlayerInput.DashInput;
        bool isDash = this.playerManager.PlayerSO.isDash;
        bool canDash = this.playerManager.PlayerSO.canDash;
        bool isGround = this.playerManager.PlayerSO.isGround;
        bool isDashCoolDown = this.playerManager.PlayerSO.isDashCoolDown;

        if ((!isDash && canDash && dashInput == 1))
        {
            StartCoroutine(this.DoDash());
        }
        if (isGround && !isDash && !canDash && !isDashCoolDown)
        {
            StartCoroutine(this.DashCoolDown());
        }
    }
    protected virtual IEnumerator DoDash()
    {
        float dashSpeed = this.playerManager.PlayerSO.dashSpeed;
        float dashTime = this.playerManager.PlayerSO.dashTime;

        //Get X and Y Input with jump and move input
        this.playerManager.PlayerSO.xInput = this.playerManager.PlayerInput.MoveInput;
        this.playerManager.PlayerSO.yInput = this.playerManager.PlayerInput.JumpInput;

        //Do dash 
        this.dashRender.emitting = true;
        this.playerManager.PlayerSO.isDashCoolDown = false;
        this.playerManager.PlayerSO.canDash = false;
        this.playerManager.PlayerSO.isDash = true;
        this.SetGravityScale(0);
        this.playerManager.Rb.velocity = dashSpeed * this.DashInput();
        
        //Wait until the end of dash
        yield return new WaitForSeconds(dashTime); 
        this.AfterDash();
    }

    protected virtual Vector2 DashInput()
    {
        float xInput = this.playerManager.PlayerSO.xInput;
        float yInput = this.playerManager.PlayerSO.yInput;
        //if player press only dash button then dash to the direction that player is facing
        if (xInput == 0 && yInput == 0)
        {
            xInput = this.playerManager.PlayerAnimation.PlayerAvt.flipX ? -1 : 1;
        }
        //When player holds jump and move button together then dash forward
        else if ((xInput == 1 || xInput == -1) && yInput == 1)
        {
            xInput = xInput == 1 ? 1 : -1;
            yInput = 0;
        }
        Vector2 input = new Vector2(xInput, yInput);
        return input;
    }

    protected virtual void AfterDash()
    {
        float xVelocityAfterDash = this.playerManager.PlayerSO.xVelocityAfterDash;
        float yVelocityAfterDash = this.playerManager.PlayerSO.yVelocityAfterDash;

        float xInput = this.playerManager.PlayerSO.xInput;
        float yInput = this.playerManager.PlayerSO.yInput;

        if (xInput == 1 || xInput == -1 || (xInput == 0 && yInput == 0))
        {
            yVelocityAfterDash = 0f;
        }
        else if (yInput == 1)
        {
            xVelocityAfterDash = 0f;
        }

        Vector2 velocityAfterDash = new Vector2 (xVelocityAfterDash, yVelocityAfterDash);

        this.playerManager.Rb.velocity = velocityAfterDash;
        this.playerManager.PlayerSO.isDash = false;
    }

    protected virtual IEnumerator DashCoolDown()
    {
        float dashCoolDown = this.playerManager.PlayerSO.dashCoolDown;

        //Dash is cooling down
        this.playerManager.PlayerSO.isDashCoolDown = true;

        //Wait until the end of the dash cooldown
        yield return new WaitForSeconds(dashCoolDown);
        this.dashRender.emitting = false;
        this.playerManager.PlayerSO.canDash = true;
        this.playerManager.PlayerSO.isDashCoolDown = false;
    }

    //========================================Other Func===========================================
    protected virtual void SetGravityScale(float value)
    {
        this.playerManager.Rb.gravityScale = value;
    }
}
