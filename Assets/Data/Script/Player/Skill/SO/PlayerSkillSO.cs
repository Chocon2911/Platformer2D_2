using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObject/Player/Skill")]
public class PlayerSkillSO : ScriptableObject
{
    public string skillName;
    public float skillCooldown = 1f;
    public float skillChargeTime = 0f;
    public bool canShoot;
    public bool isCharging;
    public bool isShooting;
    [HideInInspector] public float xInput = 0f;
    [HideInInspector] public float yInput = 0f;
}
