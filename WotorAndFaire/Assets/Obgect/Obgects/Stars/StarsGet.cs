using System;
using System.Collections;
using UnityEngine;

public class StarsGet : MonoBehaviour
{
    public event Action<string> takeStar;
    [SerializeField] private AudioSource taleStarSound;
    [SerializeField] private Animator animastionDisable;
    [SerializeField] private GameObject patricalEffect;
    private bool playCarytin=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playCarytin)
            return;
        if (collision.tag == "Water")
        {
            this.takeStar?.Invoke(this.gameObject.name);
            StartCoroutine(SoundPlay());
        }
    }
    
    IEnumerator SoundPlay()
    {
        playCarytin=true;
        taleStarSound.Play();
        animastionDisable.SetBool("Disable", true);
        patricalEffect.SetActive(true);
        yield return new WaitForSecondsRealtime(taleStarSound.clip.length-0.5f);
        this.gameObject.SetActive(false);
    }
}
