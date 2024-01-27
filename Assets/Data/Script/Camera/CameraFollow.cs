using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : HuyMonoBehaviour
{
    [SerializeField] protected GameObject targetObj;
    [SerializeField] protected GameObject cameraObj;
    [SerializeField] protected Vector3 distance = new Vector3(0f, 0.5f, -10);

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCameraPos();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void LateUpdate()
    {
        base.LateUpdate();
        this.Follow();
    }

    protected virtual void LoadCameraPos()
    {
        if (this.cameraObj != null) return;
        this.cameraObj = GameObject.Find("Camera");
        Debug.Log(transform.name + ": LoadCameraPos", transform.gameObject);
    }

    protected virtual void Follow()
    {
        if (this.targetObj == null || this.cameraObj == null)
        {
            Debug.LogError(transform.name + ": Follow" + " (No target or camera)", transform.gameObject);
        }
        else
        {
            Vector3 yzTargetPos_ = new Vector3(0f, 
                this.targetObj.transform.position.y, 
                this.targetObj.transform.position.z);
            this.cameraObj.transform.position = this.distance - yzTargetPos_ + this.targetObj.transform.position;
        }
    }
}
