using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : HuyMonoBehaviour
{
    [SerializeField] protected Transform holderTrans;
    [SerializeField] protected Transform prefabTrans;
    [SerializeField] protected List<Transform> holderList;
    [SerializeField] protected List<Transform> prefabList;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolderTrans();
        this.LoadPrefabTrans();
        this.LoadHolderList();
        this.LoadPrefabList();
    }

    //=====================================Load Component==========================================
    protected virtual void LoadHolderTrans()
    {
        if (this.holderTrans != null) return;
        this.holderTrans = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolderTrans", transform.gameObject);
    }

    protected virtual void LoadPrefabTrans()
    {
        if (this.prefabTrans != null) return;
        this.prefabTrans = transform.Find("Prefab");
        Debug.Log(transform.name + ": LoadPrefabTrans", transform.gameObject);
    }

    protected virtual void LoadHolderList()
    {
        if (this.holderList == null) return;
        this.holderList = new List<Transform>();
        Transform holders = transform.Find("Holder");
        foreach(Transform obj in holders)
        {
            this.holderList.Add(obj);
        }
        Debug.Log(transform.name + ": LoadHolderList", transform.gameObject);
    }

    protected virtual void LoadPrefabList()
    {
        if (this.prefabList == null) return;
        this.prefabList = new List<Transform>();
        Transform prefabs = transform.Find("Prefab");
        foreach(Transform obj in prefabs)
        {
            this.prefabList.Add(obj);
        }
        Debug.Log(transform.name + ": LoadPrefabList", transform.gameObject);
    }

    //==========================================Public==============================================
    public virtual Transform Spawn(string name, Vector2 pos, Quaternion rot)
    {
        Debug.Log(transform.name + ": " + pos + " " + rot, transform.gameObject);
        Transform prefab = CheckPrefabByName(name);
        Transform newPrefab = ClonePrefab(prefab);

        newPrefab.SetPositionAndRotation(pos, rot);
        newPrefab.parent = this.holderTrans;

        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        obj.gameObject.SetActive(false);
        this.AddToHolderList(obj);
    }

    //========================================Other Func===========================================
    private Transform CheckPrefabByName(string name)
    {
        foreach (Transform obj in prefabList)
        {
            if (obj.name == name) return obj;
        }
        Debug.LogWarning("Wrong name");
        return null;
    }

    private Transform ClonePrefab(Transform prefab)
    {
        foreach (Transform obj in this.holderList)
        {
            if (obj.name == prefab.name + "(Clone)")
            {
                this.holderList.Remove(obj);
                Debug.Log(transform.name + ": Get prefab from holder", transform.gameObject);
                return obj;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        Debug.Log(transform.name + ": Instantiate new prefab", transform.gameObject);
        return newPrefab;
    }

    private void AddToHolderList(Transform obj)
    {
        this.holderList.Add(obj);
    }
}
