using UnityEngine;

namespace Move
{
    public class RayCastControllerAndroind : MonoBehaviour
    {
        [SerializeField] private Camera cameraUI;
        public LayerMask layer;

        private string nameButtonDoun;
        private bool buttonDounUp = true;
        private bool buttonDounDoun = false;
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                
                buttonDounUp = true;
                RaycastHit hit;
                Ray ray = cameraUI.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f, layer))
                {
                    this.nameButtonDoun = hit.transform.name;  
                }
            }
            else
            {
                buttonDounDoun = false;
                buttonDounUp = false;
            }
        }
        public bool ButtonGet(string nameButton)
        {
            if (nameButtonDoun == nameButton)
            {
                nameButtonDoun = null;
                return true;
            }
            return false;
        }

        public bool ButtonDown(string nameButton)
        {
            if (nameButtonDoun == nameButton && !buttonDounDoun && buttonDounUp)
            {
                nameButtonDoun = null;
                buttonDounDoun = true;
                return true;
            }
            return false;
        }
        public bool ButtonUp(string nameButton)
        {
            if (nameButtonDoun == nameButton && !buttonDounUp)
            {
                nameButtonDoun = null;
                buttonDounUp = true;
                return true;
            }
            return false;
        }
    }
}