using UnityEngine;
using State;

public class SvitchButtonByState : MonoBehaviour
{
    [SerializeField] private StateMashin plaer;
    [SerializeField] private GameObject buttonMuve;
    [SerializeField] private GameObject buttonFaly;
    void Start()
    {
        plaer.svitchStateMove += EnbleMoveButton;
        plaer.svitchStateFlay += EnbleFalyButton;
    }

    private void EnbleMoveButton()
    {
        buttonMuve.SetActive(true);
        buttonFaly.SetActive(false);
    }
    private void EnbleFalyButton()
    {
        buttonMuve.SetActive(false);
        buttonFaly.SetActive(true);
    }
}
