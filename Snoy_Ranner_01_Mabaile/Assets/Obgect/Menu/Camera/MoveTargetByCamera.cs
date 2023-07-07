using UnityEngine;

namespace Menu
{
    public class MoveTargetByCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void Start()
        {
            this.target = this.transform;
        }
        void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.fixedDeltaTime * 5f);
        }

        public void SelectTarget(Transform posihion)
        {
            target = posihion;
        }
    }
}