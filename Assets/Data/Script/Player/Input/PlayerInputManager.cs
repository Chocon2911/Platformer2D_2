using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : HuyMonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveInput;
    public float MoveInput => moveInput;

    [SerializeField] private float verticalInput;
    public float VerticalInput => verticalInput;

    [SerializeField] private float jumpInput;
    public float JumpInput => jumpInput;

    [SerializeField] private float dashInput;
    public float DashInput => dashInput;

    [Header("Skill")]
    [SerializeField] private float jSkillInput;
    public float JSkillInput => jSkillInput;

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    protected override void Update()
    {
        base.Update();
        this.GetMoveInput();
        this.GetSkillInput();
    }

    //=====================================Update========================================
    //=================================Get User Input====================================
    protected virtual void GetMoveInput()
    {
        this.moveInput = Input.GetAxisRaw("Horizontal");
        this.verticalInput = Input.GetAxisRaw("Vertical");
        this.jumpInput = Input.GetAxisRaw("Jump");
        this.dashInput = Input.GetAxisRaw("Dash");
    }

    protected virtual void GetSkillInput()
    {
        this.GetJSkillInput();
    }

    protected virtual void GetJSkillInput()
    {
        if (Input.GetKey(KeyCode.J) || Input.GetKeyDown(KeyCode.J)) this.jSkillInput = 1;
        else this.jSkillInput = 0;
    }
}
