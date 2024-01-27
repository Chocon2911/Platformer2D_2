using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillManager : HuyMonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    public PlayerManager PlayerManager => playerManager;

    [SerializeField] private PlayerSkillSpawnPos playerSkillSpawnPos;
    public PlayerSkillSpawnPos PlayerSkillSpawnPos => playerSkillSpawnPos;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerManager();
        this.LoadPlayerSkillSpawnPos();
    }

    protected virtual void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = transform.parent.GetComponent<PlayerManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }

    protected virtual void LoadPlayerSkillSpawnPos()
    {
        if (this.playerSkillSpawnPos != null) return;
        this.playerSkillSpawnPos = transform.Find("SpawnPos").GetComponent<PlayerSkillSpawnPos>();
        Debug.Log(transform.name + ": LoadPlayerSkillSpawnPos", transform.gameObject);
    }
}
