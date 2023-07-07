using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Plaer : MonoBehaviour
{
    public DataPlaerWho plaerWho;

    [SerializeField] private Animator plaerAnimashion;
    [SerializeField] private Questions questions;
    [SerializeField] private GameObject plaerGrafic;
    [SerializeField] private Image foto;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI textPlaer;
    [SerializeField] private YandexSDK reclama;

    public void Init()
    {
        questions.eventFinal += LodingPlaer;
    }
    void LodingPlaer(string path,int lavelGoodAndBead,int lavelOrderAndChaos)
    {
        if (lavelGoodAndBead == 0)//Это я долбаеб и не правильно посчитал колличество персонажей
            lavelGoodAndBead++;
        if (lavelOrderAndChaos == 0)
            lavelOrderAndChaos++;
        this.plaerWho = LodingXMLDataPlaer.Loding("Question/" + path + "/plaer", lavelGoodAndBead, lavelOrderAndChaos);
        this.plaerGrafic.SetActive(true);
        this.foto.sprite = this.plaerWho.foto;
        this.icon.sprite = this.plaerWho.icon;
        this.textPlaer.text= this.plaerWho.text;
        if (path == "WhoYouStalker")
        {
            PlayerPrefs.SetInt("plaer" + lavelGoodAndBead + lavelOrderAndChaos, 1);
            PlayerPrefs.Save();
        }
        if (path== "WhoYouLavelStalker")
        {
            int titel = lavelGoodAndBead * 100 + Random.Range(0, 99);
            this.textPlaer.text += " \n" + "Очки: " + titel;
            reclama.SetTitelLiderbordRating(titel);
            Time.timeScale = 0;
        }
        plaerAnimashion.SetTrigger("Enable");
    }
    public void IfPlaerNorReag()
    {
        this.textPlaer.text += " \n" + "(Чтобы ваш рейтинг добавился в лидерборд нужно авторизироваться.)";
    }
}
