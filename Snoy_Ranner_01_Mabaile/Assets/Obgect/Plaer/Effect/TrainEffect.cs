using Move;
using UnityEngine;

public class TrainEffect : MonoBehaviour
{
    [SerializeField] private Controller move;
    [SerializeField] private GameObject FervardEffect;
    [SerializeField] private GameObject BeakEffect;

    private bool triger=true;
    void Update()
    {
        if(move.moveForvord && triger)
        {
            FervardEffect.SetActive(false);
            BeakEffect.SetActive(true);
            triger = !triger;
        }
        if(!move.moveForvord && !triger)
        {
            FervardEffect.SetActive(true);
            BeakEffect.SetActive(false);
            triger = !triger;
        }
    }
}
