using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour, IInit
{
    [SerializeField] private AudioMixerGroup mainMixer;
    [SerializeField] private Image obgectImagSound;
    [SerializeField] private Sprite enableImagSound;
    [SerializeField] private Sprite disableImagSound;
    [SerializeField] private Image obgectImagMusic;
    [SerializeField] private Sprite enableImagMusic;
    [SerializeField] private Sprite disableImagMusic;
    [SerializeField]  private int enableSound;
    [SerializeField]  private int enableMusic;
    public bool InitStart()
    {
        LodingSoundAndMusic();
        return true;
    }
    private void SelectSound()
    {
        if (enableSound == 1)
        {
            mainMixer.audioMixer.SetFloat("Sound", 0f);
            obgectImagSound.sprite= enableImagSound;


        }
        else
        {
            mainMixer.audioMixer.SetFloat("Sound", -80f);
            obgectImagSound.sprite = disableImagSound;
        }
    }
    private void SelectMusic()
    {
        if (enableMusic == 1)
        {
            mainMixer.audioMixer.SetFloat("Music", 0f);
            obgectImagMusic.sprite= enableImagMusic;
        }
        else
        {
            mainMixer.audioMixer.SetFloat("Music", -80f);
            obgectImagMusic.sprite = disableImagMusic;
        }
    }
    private void LodingSoundAndMusic()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            enableSound = PlayerPrefs.GetInt("Sound");
        }
        else
        {
            enableSound = 1;
        }
        if (PlayerPrefs.HasKey("Music"))
        {
            enableMusic = PlayerPrefs.GetInt("Music");
        }
        else
        {
            enableMusic = 1;
        }
        SelectSound();
        SelectMusic();

        PlayerPrefs.SetInt("Sound", enableSound);
        PlayerPrefs.SetInt("Music", enableMusic);
    }
    public void SvitchSound()
    {
        if (enableSound == 1)
        {
            enableSound = 0;
        }
        else
        {
            enableSound = 1;
        }
        SelectSound();
        PlayerPrefs.SetInt("Sound", enableSound);
    }
    public void SvitchMusic()
    {
        if (enableMusic == 1)
        {
            enableMusic = 0;
        }
        else
        {
            enableMusic = 1;
        }
        SelectMusic();
        PlayerPrefs.SetInt("Music", enableMusic);
    }
   
    
}
