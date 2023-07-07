using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataQuestion 
{
    public Sprite foto;
    public string text;
    public List<AnsversStrust> ansver;

    public DataQuestion()
    {
        this.ansver = new List<AnsversStrust>();
    }
}
