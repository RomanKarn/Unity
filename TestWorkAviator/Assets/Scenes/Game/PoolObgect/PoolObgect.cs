using System.Collections.Generic;
using UnityEngine;

public class PoolObgect
{
    public GameObject prefab { get; }
    public bool avtoExpand { get; set; }
    public Transform contaner { get; }

    private List<GameObject> pool;

    public PoolObgect(GameObject prefab, int count, Transform contaner, bool avtoExpand)
    {
        this.prefab = prefab;
        this.contaner = contaner;
        this.avtoExpand = avtoExpand;
        this.CreatPool(count);
    }

    private void CreatPool(int count)
    {
        this.pool = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObgect(false);
        }
    }

    private GameObject CreateObgect(bool isActivByDefalt = false)
    {
        var createdObgetc = Object.Instantiate(this.prefab, this.contaner);
        createdObgetc.gameObject.SetActive(isActivByDefalt);
        this.pool.Add(createdObgetc);
        return createdObgetc;
    }

    public bool HasFreeElement(out GameObject element)
    {
        foreach (var mono in pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                mono.gameObject.SetActive(true);
                element = mono;
                return true;
            }
        }
        element = null;
        return false;
    }

    public GameObject GetFreeElement()
    {
        if (this.HasFreeElement(out var element))
        {
            return element;
        }
        if (this.avtoExpand)
        {
            return this.CreateObgect(true);
        }
        Debug.Log(this.avtoExpand);
        Debug.Log(prefab.name);
        throw new System.Exception($"Not Foind free element {typeof(GameObject)}");
    }

    public List<GameObject> ReturnListElements()
    {
        return this.pool;
    }

}
