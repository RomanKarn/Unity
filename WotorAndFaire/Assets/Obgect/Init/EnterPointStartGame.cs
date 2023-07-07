using System.Collections.Generic;
using UnityEngine;

public class EnterPointStartGame : MonoBehaviour
{
    [SerializeField] public GameObject cameraInit;

    [SerializeField] public List<GameObject> globalPoolForspavnerInit;
    [SerializeField] public List<GameObject> spavnerInitPool;
    [SerializeField] public List<AnimashionDino> animashionDino;
    [SerializeField] private MovForLodingFon lodingFon;
    [SerializeField] private PlaerManagerGame plaer;
    [SerializeField] private SoundSetting sound;
    [SerializeField] private SceilRadius sliderSceilRaius;
    void Start()
    {
        InitSpavner();
        InitCamera();
        InitPlaer();
        InitFon();
        InitSladerRudiusSlider();
        InitSoundAndMusic();
        InitDino();
    }

    private void InitDino()
    {
        foreach (var item in animashionDino)
        {
            item.InitStart();
        }
    }
    private void InitSladerRudiusSlider()
    {
        sliderSceilRaius.GetComponent<IInit>().InitStart();
    }
    private void InitSoundAndMusic()
    {
        sound.GetComponent<IInit>().InitStart();
    }
    private void InitPlaer()
    {
        plaer.transform.GetComponent<IInit>().InitStart();
    }
    private void InitFon()
    {
        lodingFon.Disable();
    }
    private bool InitSpavner()
    {
        bool returnFinal = false;
        foreach (GameObject spavner in globalPoolForspavnerInit)
        {
            returnFinal = spavner.transform.GetComponent<IInit>().InitStart();
        }
        if (returnFinal)
        {
            foreach (GameObject spavner in spavnerInitPool)
            {
                returnFinal = spavner.GetComponent<IInit>().InitStart();
            }
        }
        return returnFinal;
    }

    private bool InitCamera() 
    {
        bool returnFinal = false;
        returnFinal = cameraInit.GetComponent<IInit>().InitStart();
        return returnFinal;
    }
}
