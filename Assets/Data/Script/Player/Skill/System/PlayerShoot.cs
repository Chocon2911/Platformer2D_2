using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : HuyMonoBehaviour
{
    [SerializeField] protected PlayerSkillManager playerSkillManager;
    public PlayerSkillManager PlayerSkillManager => playerSkillManager;

    [SerializeField] protected PlayerSkillSO skillSO;
    public PlayerSkillSO SkillSO => skillSO;

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

    //=========================================Shoot===============================================
    public virtual IEnumerator DoShoot()
    {
        float skillChargeTime = this.skillSO.skillChargeTime;
        float skillCooldown = this.skillSO.skillCooldown;

        this.ChargeSkill();
        yield return new WaitForSeconds(skillChargeTime);

        this.ShootSkill();
        yield return new WaitForSeconds(skillCooldown);

        this.AfterSkillCooldown();
    }

    protected virtual void ChargeSkill()
    {
        this.skillSO.canShoot = false;
        this.skillSO.isCharging = true;

        this.skillSO.xInput = this.playerSkillManager.PlayerManager.PlayerAnimation.PlayerAvt.flipX ? -1 : 1;
        this.skillSO.yInput = this.playerSkillManager.PlayerManager.PlayerInput.VerticalInput;
        Debug.Log(transform.name + "Charge Skill", transform.gameObject);
    }

    protected virtual void ShootSkill()
    {
        this.skillSO.isCharging = false;
        Debug.Log(transform.name + "Shoot Skill", transform.gameObject);
        //For Override
    }

    protected virtual void AfterSkillCooldown()
    {
        this.skillSO.canShoot = true;
    }
}
