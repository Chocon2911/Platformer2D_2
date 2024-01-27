using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : HuyMonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerManager();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
        this.VelocityCtrl();
    }

    //=====================================Load Component==========================================
    protected virtual void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = transform.GetComponent<PlayerManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }

    //====================================Player Velocity==========================================
    protected virtual void VelocityCtrl()
    {
        Rigidbody2D rb = this.playerManager.Rb;
        float maxFallSpeed = this.playerManager.PlayerSO.maxFallSpeed;

        if (rb.velocity.y < -maxFallSpeed)
        {
            float currXVelocity = this.playerManager.Rb.velocity.x;
            this.playerManager.Rb.velocity = new Vector2 (currXVelocity, -maxFallSpeed);
        }
    }
}
