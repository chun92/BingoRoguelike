using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFactory 
{
    private const string DEFAULT_PATH = "Resources/Images/Skill";
    public static SkillFactory skillFactory = null;
    public static SkillFactory getInstance()
    {        
        if (skillFactory == null)
        {
            skillFactory = new SkillFactory();
        }
        return skillFactory;
    }

}
