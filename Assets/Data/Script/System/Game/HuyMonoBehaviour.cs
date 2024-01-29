using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HuyMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponent();
    }

    protected virtual void Reset()
    {
        this.ResetValue();
        this.LoadComponent();
    }
    protected virtual void LoadComponent()
    {
        // For override
    }

    protected virtual void Start()
    {
        // For override
    }

    protected virtual void ResetValue()
    {
        // For override
    }

    protected virtual void Update()
    {
        // For override
    }

    protected virtual void FixedUpdate()
    {
        // For override
    }

    protected virtual void LateUpdate()
    {
        // For override
    }

    protected virtual void OnEnable()
    {
        // For override
    }
}
