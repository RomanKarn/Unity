using System.Collections;
using UnityEngine;

public class AnimashionDino : MonoBehaviour, IInit
{
    [SerializeField] private Transform endPosihion;
    [SerializeField] private float speed = 2;
    [SerializeField] private PlaerManagerGame plaer;

    private Animator dinoAnimator;
    public bool InitStart()
    {
        plaer.plaerWin += StrtWalk;
        dinoAnimator=this.GetComponent<Animator>();
        return true;
    }

    IEnumerator Walk()
    {
        while (Vector2.Distance(this.transform.position, endPosihion.position)>0.1f)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, endPosihion.position, speed * Time.deltaTime);
            yield return null;
        }
        dinoAnimator.SetBool("Drink", true);
    }

    private void StrtWalk()
    {
        StartCoroutine(Walk());
        dinoAnimator.SetBool("Walk", true);
    }
}
