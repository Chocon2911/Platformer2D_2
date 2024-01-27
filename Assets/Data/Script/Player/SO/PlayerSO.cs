using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Movement", menuName = "ScriptableObject/Player/Movement")]
public class PlayerSO : ScriptableObject
{
    [Header("Movement")]
    [Header("Run")]
    public float maxSpeed = 10f;
    public float accel = 10f;
    public float deAccel = 10f;

    [Header("Jump")]
    public float jumpHeight = 15f;
    public float airJumpBorder = 1f;
    public bool isJump;

    [Header("Fall")]
    public float maxFallSpeed = 10f;
    public float baseGravityScale = 1f;
    public float airGravity = 0.1f;

    [Header("Dash")]
    public float dashSpeed = 15f;
    public float dashTime = 0.5f;
    public float dashCoolDown = 1f;
    public float xVelocityAfterDash = 0f;
    public float yVelocityAfterDash = 0f;
    [HideInInspector] public float xInput = 0f;
    [HideInInspector] public float yInput = 0f;
    public bool isDash;
    public bool canDash;
    public bool isDashCoolDown;

    [Header("Collide")]
    public bool isGround;
    public bool isLeftWall;
    public bool isRightWall;
}