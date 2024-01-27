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
        Vector2 dir = GetDirFromRot(zRot);
        rb.velocity = dir.normalized * speed;
    }

    protected virtual Vector2 GetDirFromRot(float angle)
    {
        float xDir = Mathf.Cos(angle);
        float yDir = Mathf.Sin(angle);

        Vector2 dir = new Vector2(xDir, yDir);
        return dir;
    }
}
