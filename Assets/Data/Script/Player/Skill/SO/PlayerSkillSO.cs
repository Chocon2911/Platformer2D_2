using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObject/Player/Skill")]
public class PlayerSkillSO : ScriptableObject
{
    public float skillCooldown = 1f;
    public float skillChargeTime = 0f;
    public bool isCharging;
    public bool isShooting;
}
