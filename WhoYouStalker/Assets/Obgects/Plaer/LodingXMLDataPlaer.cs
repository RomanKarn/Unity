using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public static class LodingXMLDataPlaer
{
    public static DataPlaerWho Loding(string path, int lavelGoodAndBead, int lavelOrderAndChaos)
    {
        return LodingXMLPlaer(path,lavelGoodAndBead, lavelOrderAndChaos);
    }
    private static DataPlaerWho LodingXMLPlaer(string path, int lavelGoodAndBead, int lavelOrderAndChaos)
    {
        DataPlaerWho plaerWho = new DataPlaerWho();
        string filepathDataPlaer = path;
        string filepathDataPlaerFoto = "Plaer/Foto/";
        string filepathDataPlaerIcon = "Plaer/IconeGrup/";

        TextAsset textAsset = (TextAsset)Resources.Load(filepathDataPlaer);
        if (textAsset==null)
        {
            Debug.Log("Error");
            return null;
        }
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList dataList = xmlDoc.GetElementsByTagName("plaer");

        foreach (XmlNode question in dataList)
        {
            if ((int.Parse(question.Attributes["lavelGoodAndBead"].Value) == lavelGoodAndBead) && (int.Parse(question.Attributes["lavelOrderAndChaos"].Value) == lavelOrderAndChaos))
            {
                foreach (XmlNode questionItems in question)
                {
                    if (questionItems.Name == "foto")
                        plaerWho.foto = LodingFoto(filepathDataPlaerFoto + questionItems.InnerText);
                    if (questionItems.Name == "icon")
                        plaerWho.icon = LodingFoto(filepathDataPlaerIcon + questionItems.InnerText);
                    if (questionItems.Name == "text")
                        plaerWho.text = questionItems.InnerText;
                }
            }
        }
        return plaerWho;
    }

    private static Sprite LodingFoto(string url)
    {
        var sprite = Resources.Load<Sprite>(url);
        return sprite;
    }
}
