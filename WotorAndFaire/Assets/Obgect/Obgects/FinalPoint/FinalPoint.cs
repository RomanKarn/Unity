using System;
using UnityEngine;
using UnityEngine.UI;

public class FinalPoint : MonoBehaviour
{
    public event Action contanerFul;
    [SerializeField] private AudioSource dingSound;
    [SerializeField] private GameObject sliderObgect;
    private Slider slider;
    [SerializeField] private GameObject typeWater;
    [SerializeField] private int colWaterForWin;

    [SerializeField] private int col=0;
    private bool fullContner = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fullContner)
            return;
        if(collision.name== typeWater.name + "(Clone)")
        {
            if (!sliderObgect.activeInHierarchy)
            {
                sliderObgect.SetActive(true);
                slider= sliderObgect.gameObject.GetComponent<Slider>();   
            }
            col++;
            slider.value = (float)(float)(col / (float)colWaterForWin);
            dingSound.PlayOneShot(dingSound.clip, 1F);
            if (col>= colWaterForWin)
            {
                contanerFul?.Invoke();
                fullContner = true;
            }
        }
    }
}
