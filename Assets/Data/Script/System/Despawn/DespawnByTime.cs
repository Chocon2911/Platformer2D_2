using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DespawnByTime : Despawner
{
    public void DespawnTime(float time)
    {
        if (time <= 0)
        {
            Debug.LogWarning(transform.name + ": time need to be greater than 0", transform.gameObject);
        }
        this.StartCoroutine(this.CountDown(time));
    }

    private IEnumerator CountDown(float time)
    {
        yield return new WaitForSeconds(time);
        this.canDespawn = true;
    }
}
