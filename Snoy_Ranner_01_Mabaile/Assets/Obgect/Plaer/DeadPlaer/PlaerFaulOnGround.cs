using UnityEngine;
using State;
public class PlaerFaulOnGround : MonoBehaviour
{
    [SerializeField] private StateMashin stateMashin;
    private void OnCollisionEnter(Collision collision)
    {
        
        if ((collision.transform.tag == "Ground" || collision.transform.tag == "SpeedPlatform" || collision.transform.tag == "Dangeros"))
        {
            stateMashin.StateDead();
        }
    }
}
