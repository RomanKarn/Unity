using UnityEngine;

namespace Spavn
{
    public abstract class MainSpavner : MonoBehaviour, IInit
    {
        [SerializeField] private GlobalPoolWaterObgect poolWater;
        public virtual bool InitStart() { return true; }
        protected void SpavnWater(int col,Vector2 posihion,string nameSpavn)
        {
            for (int i = 0; i < col; i++)
            {
               GameObject newObget =  poolWater.ReturnPoolObgect(nameSpavn).GetFreeElement();
               newObget.transform.position = posihion; 
            }
        }
    }
}