using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CI.QuickSave;
using System;

public class PlaerManagerGame : MonoBehaviour,IInit, ISaveStar
{
    public event Action plaerWin;

    [SerializeField] private string dichinori;

    [SerializeField] private int starHave;
    [SerializeField] private List<StarsGet> starGet;
    [SerializeField] private List<FinalPoint> contanerForWater;

    [SerializeField] private MovForLodingFon lodingFon;
    [SerializeField] private GameObject menuWin;
    [SerializeField] private GameObject buttonNextLevel;
    [SerializeField] private List<GameObject> stars;
    [SerializeField] private List<string> starsHaveNames;
    [SerializeField] private int colContanersFull=0;
    private bool enableFinal=false;
    public bool InitStart()
    {
        foreach (var star in starGet)
        {
            star.takeStar += AddStar;
        }
        foreach (var star in contanerForWater)
        {
            star.contanerFul += CheakContanerFull;
        }
        return true;
    }

    private void AddStar(string nameHave)
    {
        if (starsHaveNames != null)
        {
            foreach (var item in starsHaveNames)
            {
                if (item == nameHave)
                    return;
            }
        }
        starHave++;
        starsHaveNames.Add(nameHave);
    }

    private void CheakContanerFull()
    {
        if (enableFinal)
            return;
        colContanersFull++;
        if(colContanersFull >= contanerForWater.Count)
        {
            PlaerWin();
            enableFinal = true;
        }
    }

    private void PlaerWin()
    {
        menuWin.SetActive(true);
        EnableNextLavelButton();
        SaveDataScoreThisLevel();
        EableStars();
        plaerWin?.Invoke();
    }

    public void MenuButton()
    {
        StartCoroutine(LodingSceneAsyn("Menu"));
    }
    public void RestsrtButton()
    {
        StartCoroutine(LodingSceneAsyn(SceneManager.GetActiveScene().name));
    }

    private void EnableNextLavelButton()
    {
        string nameNextScene = SceneManager.GetActiveScene().name;
        nameNextScene = nameNextScene.Remove(0, 5);
        int namberLavel = int.Parse(nameNextScene);
        namberLavel++;
        int indexNextLavel = SceneUtility.GetBuildIndexByScenePath("Lavel" + namberLavel);
        if (indexNextLavel == -1)
            return;
        buttonNextLevel.SetActive(true);

    }
    public void NextLavelButton()
    {
        string nameNextScene = SceneManager.GetActiveScene().name;
        nameNextScene = nameNextScene.Remove(0, 5);
        int namberLavel = int.Parse(nameNextScene);
        namberLavel++;
        int indexNextLavel = SceneUtility.GetBuildIndexByScenePath("Lavel" + namberLavel);
        if (indexNextLavel == -1)
            return;
        StartCoroutine(LodingSceneAsyn(indexNextLavel));
    }

    IEnumerator LodingSceneAsyn(string nameScene)
    {
        lodingFon.Eable();
        yield return new WaitForSecondsRealtime(1); 
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameScene);
    }
    IEnumerator LodingSceneAsyn(int idScene)
    {
        lodingFon.Eable();
        yield return new WaitForSecondsRealtime(1); 
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(idScene);

    }

    private void SaveDataScoreThisLevel()
    {
        if (starHave < LoadGameStar(this.dichinori, SceneManager.GetActiveScene().name))
            return;
        Debug.Log("Save");
        SaveGameStar(this.dichinori, SceneManager.GetActiveScene().name, starHave);
    }
    public void SaveGameStar(string dichinori, string key, int col)
    {
        QuickSaveWriter wrate = QuickSaveWriter.Create(dichinori);
        wrate.Write(key, col)
                      .Commit();
    }
    public int LoadGameStar(string dichinori, string key)
    {
        if (!QuickSaveRaw.Exists(dichinori + ".json"))
            return 0;
        QuickSaveReader reader = QuickSaveReader.Create(dichinori);
        if (!reader.Exists(key))
            return 0;
        var result = reader.Read<int>(key);
        return result;
    }

    private void EableStars()
    {
        for(int i=0;i< starHave;i++)
        {
            stars[i].SetActive(true);
        }
    }
}
