using UnityEngine;

namespace Spavn
{
    public class StartSpavnerAllWater : MainSpavner
    {
        [SerializeField] private GameObject obgectSpavn;
        [SerializeField] private int colSpavnWater;
        [SerializeField] private float radiusSpavnWater;
        private Vector2 posishionSpavnWater;
        public override bool InitStart()
        {
            posishionSpavnWater=this.transform.position;
            SpavnRandomRange();
            return true;
        }

        private void SpavnRandomRange()
        {
            for (int i = 0; i < colSpavnWater; i++)
            {
                posishionSpavnWater.x += Random.Range(-radiusSpavnWater, radiusSpavnWater);
                posishionSpavnWater.y += Random.Range(-radiusSpavnWater, radiusSpavnWater);
                SpavnWater(1, posishionSpavnWater, obgectSpavn.name);
            }
        }
    }
}