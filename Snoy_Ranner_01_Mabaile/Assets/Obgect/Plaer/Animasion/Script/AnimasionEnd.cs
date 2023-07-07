using UnityEngine;

public class AnimasionEnd : MonoBehaviour
{
    [SerializeField] private Animator animatorPlaer;

    public void EndAnimashion()
    {
        animatorPlaer.SetBool("AnimasionPlay", false);
    }
}
