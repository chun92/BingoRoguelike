using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    public string name { get; }
    public Sprite image { get; }
    private List<Skill> skills;

    public Unit(string name, Sprite image)
    {
        this.name = name;
        this.image = image;
        skills = new List<Skill>();
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
