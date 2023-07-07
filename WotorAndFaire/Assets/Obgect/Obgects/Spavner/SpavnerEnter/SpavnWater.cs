using System.Collections;
using TMPro;
using UnityEngine;

namespace Spavn
{
    public class SpavnWater : MainSpavner
    {
        [SerializeField] private AudioSource explosenSpavnerSound;
        [SerializeField] private AudioSource spavnSound;

        [SerializeField] private Color textColorDisable;
        [SerializeField] private TextMeshPro textColor;
        [SerializeField] private int allCollSpavn;
        [SerializeField] private int collSpavn;
        [SerializeField] private bool disableWork=false;

        [SerializeField] private GameObject spavnEffect;
        [SerializeField] private GameObject distroiEffect;
        [SerializeField] private float timerPlayEffect=0.1f;
        private bool playEffect;
        private void OnTriggerEnter2D(Collider2D collision)
        { 
            if (disableWork)
                return;
            if (collision.tag == "DisableWall")
            {
                disableWork = true;
                return;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (disableWork)
                return;
            if (allCollSpavn > 0)
            {
                if (!playEffect)
                {
                    playEffect = true;
                    spavnEffect.SetActive(true);
                    spavnSound.pitch = Random.Range(0.9f, 1.1f);
                    spavnSound.Play();
                    StartCoroutine(EnablePartical());
                }
                SpavnWater(collSpavn, collision.transform.position, collision.name.Remove(collision.name.Length - 7));
                allCollSpavn-= collSpavn;
            }
            else
            {
                disableWork = true;
                textColor.color = textColorDisable;
                distroiEffect.SetActive(true);
                explosenSpavnerSound.Play();
            }
        }

        IEnumerator EnablePartical()
        {
            yield return new WaitForSecondsRealtime(timerPlayEffect);
            spavnEffect.SetActive(false);
            playEffect = false;
        }
    }
}