using UnityEngine;

namespace Terrain
{
    public class Chank : MonoBehaviour
    {
        [SerializeField] public Transform startPoint;
        [SerializeField] public Transform endPoint;

        [SerializeField] public AnimationCurve cangeFromDstans;
    }
}