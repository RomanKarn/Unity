using UnityEngine;
using State;
public class PlaerDeadEndAnimashion : MonoBehaviour
{
    [SerializeField] private StateMashin stateMashin;

    private Animator animator;
    void Start()
    {
        stateMashin.svitchStateDaed += SelectStateDead;
        this.animator = GetComponent<Animator>();
    }

    private void SelectStateDead()
    {
        animator.enabled= false;
    }
}
