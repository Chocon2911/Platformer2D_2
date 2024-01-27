using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpikeShooting : HuyMonoBehaviour
{
    [SerializeField] private PlayerSkillManager playerSkillManager;
    public PlayerSkillManager PlayerSkillManager => playerSkillManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerSkillManager();
    }

    //====================================Load Component===========================================
    protected virtual void LoadPlayerSkillManager()
    {
        if (this.playerSkillManager != null) return;
        this.playerSkillManager = transform.parent.GetComponent<PlayerSkillManager>();
        Debug.Log(transform.name + ": LoadPlayerSkillManager", transform.gameObject);
    }

    //========================================Shoot================================================
    protected virtual void Shoot()
    {
        float jSkillInput = this.playerSkillManager.PlayerManager.PlayerInput.JSkillInput;

    }
}
