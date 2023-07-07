using UnityEngine;

public class MovForLodingFon : MonoBehaviour
{
    [SerializeField] private Animator lodingFonAnimator;
    [SerializeField] private SpriteRenderer lodingFon;
    public void Eable()
    {
        lodingFonAnimator.SetBool("Enable",true);
    }

    public void Disable()
    {
        lodingFonAnimator.SetBool("Disable", true);
    }
    public void EableObgect()
    {
        lodingFon.enabled=true;
    }
    public void DisableObgect()
    {
        lodingFon.enabled=false;
    }


}
