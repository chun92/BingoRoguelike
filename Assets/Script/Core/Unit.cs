using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class UnitRawData : RawData
{
    public int[] skills;
}

public class Unit : BaseObject
{
    public List<Skill> skills;

    public Unit() : base()
    {

    }

    public Unit(int id, string name, Sprite image) : base(id, name, image)
    {
        skills = new List<Skill>();
    }
    
    public Unit(int id, string name, Sprite image, List<Skill> skills) : base(id, name, image)
    {
        this.skills = skills;
    }

    public delegate void skillCallback(Skill s, int index);

    public void loopSkills(skillCallback callback)
    {
        int i = 0;
        foreach (Skill s in skills)
        {
            callback.Invoke(s, i);
            i++;
        }
    }
    
    public void addSkill(Skill skill)
    {
        skills.Add(skill);
    }

    public bool hasSkill(Skill skill)
    {
        foreach (Skill s in skills)
        {
            if (s.isSameSkill(skill))
            {
                return true;
            }
        }
        return false;
    }
    public bool removeSkill(Skill skill)
    {
        Skill res = null;
        foreach (Skill s in skills)
        {
            if (s.isSameSkill(skill))
            {
                res = s;
                break;
            }
        }
        if (res != null)
        {
            skills.Remove(res);
            return true;
        } else
        {
            return false;
        }
    }
}
