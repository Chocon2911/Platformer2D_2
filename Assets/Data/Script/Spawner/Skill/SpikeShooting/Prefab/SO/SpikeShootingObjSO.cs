using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpikeShootingObj", menuName = "ScriptableObject/SpikeShootingObj")]
public class SpikeShootingObjSO : ScriptableObject
{
    public string Name;
    public float damge = 1f;
    public float speed = 10f;
    [HideInInspector] public float xDir;
    [HideInInspector] public float yDir;
}
