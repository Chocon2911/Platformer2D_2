using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkillManger : HuyMonoBehaviour
{
    [SerializeField] private SpikeShootingManager spikeShootingManager;
    public SpikeShootingManager SpikeShootingManager => spikeShootingManager;

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
