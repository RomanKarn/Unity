using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LodingLavel : MonoBehaviour,IInit
{
    [SerializeField] public string nameLodingLavel;
    [SerializeField] private MovForLodingFon lodingFon;
    [SerializeField] private List<GameObject> starButton;

    public void InitLodingButton(int star)
    {
        for(int i=0;i<star;i++)
        {
            starButton[i].SetActive(true);
        }
    }

    public bool InitStart()
    {
        throw new System.NotImplementedException();
    }

    public void LodingThisLavel()
    {
        StartCoroutine(LodingSceneAsyn());
    }

    IEnumerator LodingSceneAsyn()
    {
        lodingFon.Eable();
        yield return new WaitForSecondsRealtime(1); 
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameLodingLavel);
    }
}
