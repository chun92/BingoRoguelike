using UnityEngine;
using System;

[Serializable]
public class SkillRawData : RawData
{
    public string text;
}

public class Skill : BaseObject
{   
    public string text { set; get; }

    public Skill() : base()
    {
    }

    public Skill(int id, string name, Sprite image, string text) : base(id, name, image)
    {
        this.text = text;
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
