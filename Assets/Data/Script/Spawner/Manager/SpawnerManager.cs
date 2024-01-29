using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : HuyMonoBehaviour
{
    public static SpawnerManager Instance { get; private set; }

    [SerializeField] private SpawnSkillManger spawnSkillManager;
    public SpawnSkillManger SpawnSkillManager => spawnSkillManager;

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
        this.LoadSpawnSkillManager();
    }

    protected virtual void LoadSpawnSkillManager()
    {
        if (this.spawnSkillManager != null) return;
        this.spawnSkillManager = transform.Find("Skill").GetComponent<SpawnSkillManger>();
        Debug.Log(transform.name + ": LoadSpawnSKillManager", transform.gameObject);
    }
}
