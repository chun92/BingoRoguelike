using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitFactory : BaseObjectFactoryImpl<Unit, UnitRawData>
{
    public static UnitFactory factory = null;

    public static UnitFactory getInstance()
    {        
        if (factory == null)
        {
            factory = new UnitFactory();
        }
        return factory;
    }
    override protected Unit read(UnitRawData rawData)
    {
        Unit unit = base.read(rawData);

        try
        {
            int[] skillIds = rawData.skills;

            List<Skill> skills = new List<Skill>();
            foreach (int skillId in skillIds) 
            {
                Skill skill = SkillFactory.getInstance().get(skillId);
                if (skill == null)
                {
                    throw new Exception("skill load failed for unit: " + unit.name + ", skill id:" + skillId);
                } else
                {
                    skills.Add(skill);
                }
            }
            unit.skills = skills;
            return unit;
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return null;
        }
    }
}