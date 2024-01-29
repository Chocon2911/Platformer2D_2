using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class StraightFly : HuyMonoBehaviour
{
    public virtual void Fly(Rigidbody2D rb, float speed, float zRot)
    {
        if (rb == null)
        {
            Debug.LogWarning(transform.name + ": rb is not exist", transform.gameObject);
            return;
        }
        Vector2 dir = this.GetDirFromRot(zRot);
        rb.velocity = dir.normalized * speed;
    }

    private Vector2 GetDirFromRot(float angle)
    {
        float angleInRadians = angle * Mathf.Deg2Rad;
        float xDir = Mathf.Cos(angleInRadians);
        float yDir = Mathf.Sin(angleInRadians);

        Vector2 dir = new Vector2(xDir, yDir);
        return dir;
    }
}
