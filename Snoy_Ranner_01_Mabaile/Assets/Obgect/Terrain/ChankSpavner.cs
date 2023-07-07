using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Terrain
{
    public class ChankSpavner : MonoBehaviour
    {
        public Transform plaerPosishion;
        public Chank[] chankPrefabs;

        public Chank ferstChank;
        private List<Chank> spawnedChank= new List<Chank>();
        void Start()
        {
            spawnedChank.Add(ferstChank);
        }

        void Update()
        {
            if (plaerPosishion.position.z > spawnedChank[spawnedChank.Count-1].endPoint.position.z-200)
            {
                SpavneChank();
            }
        }

        private void SpavneChank()
        {
            Chank newChank = Instantiate(GetRandomChank());
            newChank.transform.position = spawnedChank[spawnedChank.Count- 1].endPoint.position-newChank.startPoint.position;
            spawnedChank.Add(newChank);

            if(spawnedChank.Count> 3) 
            {
                Destroy(spawnedChank[0].gameObject);
                spawnedChank.RemoveAt(0);
            }
        }

        private Chank GetRandomChank()
        {
            List<float> chanse = new List<float>();
            for (int i=0; i<chankPrefabs.Length;i++)
            {
                chanse.Add(chankPrefabs[i].cangeFromDstans.Evaluate(plaerPosishion.position.z));
            }

            float value = Random.Range(0, chanse.Sum());
            float sum = 0;

            for(int i=0;i<chanse.Count;i++)
            {
                sum += chanse[i];
                if(value<sum)
                {
                    return chankPrefabs[i];
                }
            }

            return chankPrefabs[chankPrefabs.Length - 1]; ;
        }

        
    }
}