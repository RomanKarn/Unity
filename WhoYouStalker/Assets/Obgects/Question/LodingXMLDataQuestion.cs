using System.Collections;
using System.Xml;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public static class LodingXMLDataQuestion
{
    public static List<DataQuestion> Loding(string path)
    {
        return LodingXMLQuestion(path);
    }
    private static List<DataQuestion> LodingXMLQuestion(string path)
    {
        List<DataQuestion> dataQuestions = new List<DataQuestion>();
        string filepathDataQuestions = path;
        string filepathDataQuestionsFoto = "PhotoQuestion/";

        TextAsset textAsset = (TextAsset)Resources.Load(filepathDataQuestions);
        if (textAsset==null)
        {
            Debug.Log("Error");
            return null;
        }
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);
        XmlNodeList dataList = xmlDoc.GetElementsByTagName("question");

        foreach (XmlNode question in dataList)
        {
            DataQuestion itemQuestionData = new DataQuestion();
            foreach (XmlNode questionItems in question)
            {
                if (questionItems.Name == "foto")
                    itemQuestionData.foto = LodingFoto(filepathDataQuestionsFoto + questionItems.InnerText);
                if (questionItems.Name == "text")
                    itemQuestionData.text = questionItems.InnerText;
                if (questionItems.Name == "ansvers")
                {
                    foreach (XmlNode ansver in questionItems)
                    {
                        AnsversStrust ansverNew = new AnsversStrust();
                        foreach (XmlNode ansverItem in ansver)
                        {
                            if (ansverItem.Name == "text")
                                ansverNew.text = ansverItem.InnerText;
                            if (ansverItem.Name == "type")
                                ansverNew.type = ansverItem.InnerText;
                            if (ansverItem.Name == "point")
                                ansverNew.point = int.Parse(ansverItem.InnerText);
                            
                        }
                        itemQuestionData.ansver.Add(ansverNew);
                    }
                }
            }
            dataQuestions.Add(itemQuestionData);
        }
        return dataQuestions;
    }

    private static Sprite LodingFoto(string url)
    {
        var sprite = Resources.Load<Sprite>(url);
        return sprite;
    }
}
