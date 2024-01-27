using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillSpawnPos : HuyMonoBehaviour
{
    [SerializeField] private PlayerSkillManager playerSkillManager;
    public PlayerSkillManager PlayerSkillManager => playerSkillManager;

    [SerializeField] private List<Transform> spawnPosList;
    public List<Transform> SpawnPosList => spawnPosList;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerSkillManager();
        this.LoadSpawnPosList();
    }

    protected virtual void LoadPlayerSkillManager()
    {
        if (this.playerSkillManager != null) return;
        this.playerSkillManager = transform.parent.GetComponent<PlayerSkillManager>();
        Debug.Log(transform.name + ": LoadPlayerSkillManager", transform.gameObject);
    }

    protected virtual void LoadSpawnPosList()
    {
        if (this.spawnPosList == null) return;
        foreach (Transform spawnPos in transform)
        {
            this.spawnPosList.Add(spawnPos);
        }
        Debug.Log(transform.name + ": LoadSpawnPosList", transform.gameObject);
    }
}
