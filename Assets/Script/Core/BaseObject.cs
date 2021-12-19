using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseObject
{
    public int id { get; set; }
    public string name { get; set;}
    public Sprite image { get; set;}

    public BaseObject(int id, string name, Sprite image)
    {
        this.id = id;
        this.name = name;
        this.image = image;
    }
    
    public BaseObject()
    {
    }

    public void setBaseObject(int id, string name, Sprite image) 
    {
        this.id = id;
        this.name = name;
        this.image = image;
    }
}


[Serializable]
public class RawData
{
    public string name;
    public string image;
    public int id;
}
