using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : HuyMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected PlayerManager playerManager;
    public PlayerManager PlayerManager => playerManager;

    [SerializeField] protected SpriteRenderer playerAvt;
    public SpriteRenderer PlayerAvt => playerAvt;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
        this.LoadPlayerManager();
        this.LoadPlayerAvt();
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        animator = transform.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", transform.gameObject);
    }

    protected virtual void LoadPlayerManager()
    {
        if (this.playerManager != null) return;
        this.playerManager = transform.GetComponentInParent<PlayerManager>();
        Debug.Log(transform.name + ": LoadPlayerManager", transform.gameObject);
    }

    protected virtual void LoadPlayerAvt()
    {
        if (this.playerAvt != null) return;
        this.playerAvt = transform.GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadPlayerAvt", transform.gameObject);
    }
}
