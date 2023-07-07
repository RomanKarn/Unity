using System.Collections.Generic;
using UnityEngine;
using CI.QuickSave;

public class EnterPointMenu : MonoBehaviour, ISaveStar
{
    [SerializeField] private string dichinori;
    [SerializeField] private Dictionary<string,int> lavelStars;
    [SerializeField] private List<LodingLavel> lavelName;
    [SerializeField] private MovForLodingFon lodingFon;
    [SerializeField] private SoundSetting sound;
    void Start()
    {
        InitData();
        InitStarInButton();
        InitFon();
        InitSoundAndMusic();
    }
    private void InitSoundAndMusic()
    {
        sound.GetComponent<IInit>().InitStart();
    }
    private void InitStarInButton()
    {
        foreach (var item in lavelName)
        {
            item.InitLodingButton(lavelStars[item.nameLodingLavel]);
        }
    }
    private void InitFon()
    {
        lodingFon.Disable();
    }
    private void InitData()
    {
        Loding();
        Save();
    }
    private void Save()
    {
        foreach (var item in lavelName)
        {
            SaveGameStar(this.dichinori, item.nameLodingLavel, lavelStars[item.nameLodingLavel]);
        }
    }
    private void Loding()
    {
        lavelStars = new Dictionary<string,int>();
        foreach (var item in lavelName) 
        {
            lavelStars.Add(item.nameLodingLavel, LoadGameStar(this.dichinori, item.nameLodingLavel));
        }
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

}
