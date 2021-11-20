using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill 
{   
    public string name { get; }
    public string text { get; }
    public Sprite image { get; }
    public int id { get; }

    public Skill(string name, string text, Sprite image, int id)
    {
        this.name = name;
        this.text = text;
        this.image = image;
        this.id = id;
    }

    public bool isSameSkill(Skill other)
    {
        if (other == null)
        {
            return false;
        }

        if (this.id == other.id)
        {
            return true;
        }

        return false;
    }
}
