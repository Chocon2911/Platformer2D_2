using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class PlayerAnimMovement : HuyMonoBehaviour
{
    [SerializeField] protected PlayerAnimationManager playerAnimationManager;

    protected enum movementState
    {
        idle,
        run,
        jump,
        fall
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerAnimationManager();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.AnimCtrl();
    }

    protected virtual void LoadPlayerAnimationManager()
    {
        if (this.playerAnimationManager != null) return;
        this.playerAnimationManager = transform.GetComponentInParent<PlayerAnimationManager>();
        Debug.Log(transform.name + ": LoadPlayerAnimationManager", transform.gameObject);
    }

    protected virtual void AnimCtrl()
    {
        if (this.playerAnimationManager == null)
        {
            Debug.LogError(transform.name + ": AnimCtrl (No playerAnimationManager", transform.gameObject);
        }
        else
        {
            movementState state = movementState.idle;
            float xInput = PlayerManager.Instance.PlayerInput.MoveInput;
            float currMoveSpeed = this.playerAnimationManager.PlayerManager.Rb.velocity.x;
            float currJumpSpeed = this.playerAnimationManager.PlayerManager.Rb.velocity.y;
            bool isGround = this.playerAnimationManager.PlayerManager.PlayerSO.isGround;

            if (xInput == -1)
            {
                this.playerAnimationManager.PlayerAvt.flipX = true;
            }

            else if (xInput == 1)
            {
                this.playerAnimationManager.PlayerAvt.flipX = false;
            }

            if (isGround)
            {
                if (currMoveSpeed < -1)
                {
                    state = movementState.run;
                }
                else if (currMoveSpeed > 1)
                {
                    state = movementState.run;
                }
                else
                {
                    state = movementState.idle;
                }
            }
            else if (!isGround)
            {
                if (currJumpSpeed > 0.1f)
                {
                    state = movementState.jump;
                }
                else if (currJumpSpeed <= 0.1f)
                {
                    state = movementState.fall;
                }
            }

            this.playerAnimationManager.Animator.SetInteger("State", (int)state);
        }
    }
}
