using UnityEngine;

namespace Spavn
{
    public class SpavnPointMouse : MainSpavner
    {
        [SerializeField] private Camera mainCamera;
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
              //  SpavnWater(1, (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
