using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpikeShootingManager : PlayerShoot
{
    protected override void Start()
    {
        base.Start();
        this.skillSO.canShoot = true;
    }

    protected override void Update()
    {
        base.Update();
        this.Shoot();
    }

    //========================================Shoot================================================
    protected override void ShootSkill()
    {
        base.ShootSkill();
        float xInput = this.skillSO.xInput;
        float yInput = this.skillSO.yInput;
        string skillName = this.skillSO.skillName;
        Vector2 pos = Vector2.zero;
        Quaternion rot = Quaternion.Euler(Vector3.zero);
        List<Transform> spawnPosList = this.playerSkillManager.PlayerSkillSpawnPos.SpawnPosList;
        Transform bullet;

        if (xInput == 1)
        {
            if (yInput == 0)
            {
                pos = spawnPosList[0].gameObject.transform.position;
                rot = spawnPosList[0].gameObject.transform.rotation;            
            }
            else if (yInput == 1)
            {
                pos = spawnPosList[1].gameObject.transform.position;
                rot = spawnPosList[1].gameObject.transform.rotation;            
            }
            else
            {
                Debug.LogWarning(transform.name + ": yInput is neither 0 nor 1", transform.gameObject);
            }
        }
        else if (xInput == -1)
        {
            if (yInput == 1)
            {
                pos = spawnPosList[2].gameObject.transform.position;
                rot = spawnPosList[2].gameObject.transform.rotation;
            }
            else if (yInput == 0)
            {
                pos = spawnPosList[3].gameObject.transform.position;
                rot = spawnPosList[3].gameObject.transform.rotation;
            }
            else
            {
                Debug.LogWarning(transform.name + ": yInput is neither 0 nor 1", transform.gameObject);
            }
        }
        else
        {
            Debug.LogWarning(transform.name + "error in ShootSkill", transform.gameObject);
        }

        bullet = SpawnSkillManager.Instance.SpikeShootingManager.Spawn(skillName, pos, rot);
        if (bullet == null) return;
        bullet.gameObject.SetActive(true);
        Debug.Log(transform.name + ": Bullet spawned", transform.gameObject);
    }

    protected virtual void Shoot()
    {
        float jSkillInput = this.playerSkillManager.PlayerManager.PlayerInput.JSkillInput;
        bool canShoot = this.skillSO.canShoot;
        bool isCharging = this.skillSO.isCharging;
        
        if (!isCharging && canShoot && jSkillInput == 1)
        {
            this.StartCoroutine(this.DoShoot());
        }
    }
}
