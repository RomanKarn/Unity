using UnityEngine;
using State;
public class StateMoveOrFlayAtSnoytbord : MonoBehaviour
{
    [SerializeField] private StateMashin stateMashin;
    public LayerMask layerMask;

    private Transform snoubord;
    private bool oneSvich;
    void Start()
    {
        this.snoubord = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
       
                Ray ray = new Ray(snoubord.transform.position, Vector3.down);
                Debug.DrawRay(snoubord.transform.position, Vector3.down*0.5f,Color.red);
                if (Physics.Raycast(ray, 0.5f,layerMask))
                {
                    if (oneSvich)
                        return;
                    stateMashin.StateMove();
                    oneSvich=true;
                }
                else
                {
                    if (!oneSvich)
                        return;
                    stateMashin.StateFlay();
                    oneSvich=false;
                }
            
    }
    /*
    private void OnCollisionStay(Collision collision)
    {
        if ((collision.transform.tag == "Ground" || collision.transform.tag == "SpeedPlatform") && (stateMashin.stateNow != "PlaerMove"))
        {
            stateMashin.StateMove();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if ((collision.transform.tag == "Ground" || collision.transform.tag == "SpeedPlatform") && (stateMashin.stateNow != "PlaerFlay"))
        {
            stateMashin.StateFlay();
        }
    }
    */
}