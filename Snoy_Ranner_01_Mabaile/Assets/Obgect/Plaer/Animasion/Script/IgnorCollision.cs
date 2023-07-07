using UnityEngine;

public class IgnorCollision : MonoBehaviour
{
    [SerializeField] private Collider[] allColider;
    void Start()
    {
        for (int a = 0; a < allColider.Length; a++)
        {
            for (int b = 0; allColider.Length > b; b++)
            {
                Physics.IgnoreCollision(allColider[a], allColider[b], true);
            }
        }
    }
}
