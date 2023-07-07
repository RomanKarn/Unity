using System.Collections.Generic;
using UnityEngine;

namespace Spavn
{
    [System.Serializable]
    public struct StructurePoolItem
    {
        public int poolCount;
        public bool autoExpand;
        public GameObject obgetsItemCriat;
        public Transform obgetsPool;
        public string name;
        public PoolObgect poolItem;
    }
    public class GlobalPoolWaterObgect : MonoBehaviour, IInit
    {
        public List<StructurePoolItem> allSpavnPool=new List<StructurePoolItem>(); 

        public bool InitStart()
        {
            for (int i=0;i< allSpavnPool.Count;i++) 
            {
                StructurePoolItem newItem =new StructurePoolItem();
                newItem.poolCount = allSpavnPool[i].poolCount;
                newItem.autoExpand = allSpavnPool[i].autoExpand;
                newItem.obgetsItemCriat = allSpavnPool[i].obgetsItemCriat;
                newItem.obgetsPool = allSpavnPool[i].obgetsPool;
                newItem.name = allSpavnPool[i].obgetsItemCriat.name;
                newItem.poolItem = new PoolObgect(allSpavnPool[i].obgetsItemCriat, allSpavnPool[i].poolCount, allSpavnPool[i].obgetsPool, allSpavnPool[i].autoExpand);
                allSpavnPool[i] = newItem;
            }
            return true;
        }
        public PoolObgect ReturnPoolObgect(string name)
        {
            foreach (var item in allSpavnPool)
            {
                if (item.name == name)
                    return item.poolItem;
            }
            return allSpavnPool[-1].poolItem;
        }
    }
}