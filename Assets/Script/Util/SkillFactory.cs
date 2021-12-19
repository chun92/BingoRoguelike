using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillFactory : BaseObjectFactoryImpl<Skill, SkillRawData>
{
    public static SkillFactory factory = null;

    public static SkillFactory getInstance()
    {        
        if (factory == null)
        {
            factory = new SkillFactory();
        }
        return factory;
    }
    
    override protected Skill read(SkillRawData rawData)
    {
        Skill skill = base.read(rawData);
        skill.text = rawData.text;
        return skill;
    }
}
