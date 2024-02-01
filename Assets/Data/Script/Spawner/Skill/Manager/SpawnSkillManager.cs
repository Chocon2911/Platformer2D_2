using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkillManager : HuyMonoBehaviour
{
    public static SpawnSkillManager Instance { get; private set; }

    [SerializeField] private SpikeShootingManager spikeShootingManager;
    public SpikeShootingManager SpikeShootingManager => spikeShootingManager;

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
        this.LoadSpikeShootingManager();
    }

    protected virtual void LoadSpikeShootingManager()
    {
        if (this.spikeShootingManager != null) return;
        this.spikeShootingManager = transform.Find("SpikeShooting").GetComponent<SpikeShootingManager>();
        Debug.Log(transform.name + ": LoadSpikeShootingManager", transform.gameObject);
    }
}
