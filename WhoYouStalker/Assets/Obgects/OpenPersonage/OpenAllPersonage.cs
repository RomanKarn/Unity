using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class OpenAllPersonage : MonoBehaviour
{
    [SerializeField] private GameObject buttonGameStart;
    [SerializeField] private GameObject pullPersonage;
    [SerializeField] private Animator animashion;
    [SerializeField] private GameObject parentGameObgect;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefabImag;
    private DataPlaerWho plaerWho;
    private bool open = false;

    public void OpenOrCose()
    {
        if(!open)
        {
            LodingPersonag();
            open = true;
            animashion.SetTrigger("Open");
            buttonGameStart.SetActive(false);
        }
        else
        {
            buttonGameStart.SetActive(true);
            animashion.SetTrigger("Close");
            open = false; 
        }
    }
    private void EnablePullPersonag()
    {
        pullPersonage.SetActive(true);
    }
    private void DisablePullPersonag()
    {
        pullPersonage.SetActive(false);
    }
    private void LodingPersonag()
    {
        ClearOutChiledParetButton();
        for (int i = 5;i>=-5;i--)
        {
            if (i == 0)
                continue;
            for (int j = 5; j >= -5; j--)
            {
                if(j==0)
                    continue;
               this.plaerWho = LodingXMLDataPlaer.Loding("Question/" + "WhoYouStalker" + "/plaer", i, j);
               GameObject image = Instantiate(prefabImag, parent);
               image.GetComponent<Image>().sprite = plaerWho.foto;
               if(PlayerPrefs.HasKey("plaer" + i + j))
               {
                    image.transform.GetChild(0).gameObject.SetActive(false);
               }
               
            }
        }
    }
    private void ClearOutChiledParetButton()
    {
        if (parentGameObgect.transform.childCount <= 0)
            return;
        for (int i = 0; i < parentGameObgect.transform.childCount; i++)
        {
            Destroy(parentGameObgect.transform.GetChild(i).gameObject);
        }
    }
}
