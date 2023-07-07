using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

public class YandexSDK : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowRating();

    [DllImport("__Internal")]
    private static extern void ShowNotClipReclama();

    [DllImport("__Internal")]
    private static extern void ShowFullScrinReclama();

    [DllImport("__Internal")]
    private static extern void LiderbordRating(int titel);

    [SerializeField] private AudioMixerGroup mainMixer;

    public void PlayFullScrinReclama()
    {
       ShowFullScrinReclama();
    }
    public void PlayNotClipReclama()
    {
        ShowNotClipReclama();
    }
    public void PlayShowRating()
    {
        ShowRating();
    }
    public void SetTitelLiderbordRating(int titel)
    {
        LiderbordRating(titel);
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        mainMixer.audioMixer.SetFloat("Music", 0f);
        mainMixer.audioMixer.SetFloat("Sound", 0f);
    }
    public void PausGame()
    {
        Time.timeScale = 0;
        mainMixer.audioMixer.SetFloat("Music", -80f);
        mainMixer.audioMixer.SetFloat("Sound", -80f);
    }


}
