using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : HuyMonoBehaviour
{
    public SpawnerManager Instance { get; private set; }

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
}
