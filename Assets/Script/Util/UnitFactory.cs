using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitFactory
{    
    private const string DEFAULT_METAFILE_PATH = "Metafile/Unit/";
    private const string DEFAULT_IMAGE_PATH = "Images/Unit/";

    public static Dictionary<int, Unit> unitIdDictionary;
    public static Dictionary<string, Unit> unitNameDictionary;
    public static UnitFactory unitFactory = null;
    public static UnitFactory getInstance()
    {        
        if (unitFactory == null)
        {
            unitFactory = new UnitFactory();
        }
        return unitFactory;
    }
    
    [Serializable]
    public class UnitRawData
    {
        public string name;
        public string image;
        public int[] skills;
        public int id;
    }

    public Unit getUnit(int id)
    {
        if (unitIdDictionary == null)
        {
            unitIdDictionary = new Dictionary<int, Unit>();
        }
        
        if (unitIdDictionary.ContainsKey(id))
        {
            return unitIdDictionary[id];
        } else
        {
            return null;
        }
    }

    public Unit getUnit(string name)
    {
        if (unitNameDictionary == null)
        {
            unitNameDictionary = new Dictionary<string, Unit>();
        }
        if (unitNameDictionary.ContainsKey(name))
        {
            return unitNameDictionary[name];
        } else
        {
            return null;
        }
    }

    public void loadAllUnits()
    {
        try
        {
            TextAsset[] data = Resources.LoadAll<TextAsset>(DEFAULT_METAFILE_PATH);
            if (data == null)
            {
                throw new Exception("Resource load for unit meta file failed: " + DEFAULT_METAFILE_PATH);
            }
            foreach (TextAsset t in data)
            {
                Unit unit = readUnitFromMetafile(t);
                if (unitIdDictionary == null)
                {
                    unitIdDictionary = new Dictionary<int, Unit>();
                }
                if (unitIdDictionary.ContainsKey(unit.id)) 
                {
                    throw new Exception("Unit id[" + unit.id + "] is duplicated: " + unit.name);
                } else
                {
                    unitIdDictionary.Add(unit.id, unit);
                }

                        
                if (unitNameDictionary == null)
                {
                    unitNameDictionary = new Dictionary<string, Unit>();
                }
                if (unitNameDictionary.ContainsKey(unit.name)) 
                {
                    throw new Exception("Unit Name[" + unit.name + "] is duplicated: " + unit.id);
                } else
                {
                    unitNameDictionary.Add(unit.name, unit);
                }
            }
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    private Unit readUnitFromMetafile(TextAsset data)
    {
        try
        {
            UnitRawData rawData = JsonUtility.FromJson<UnitRawData>(data.ToString());
            Unit unit = getUnit(rawData);
            return unit;
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return null;
        }
    }

    private Unit getUnit(UnitRawData rawData)
    {
        try
        {
            string name = rawData.name;
            int id = rawData.id;

            string imagePath = DEFAULT_IMAGE_PATH + rawData.image;
            Sprite image = Resources.Load<Sprite>(imagePath);
            if (image == null)
            {
                throw new Exception("Resource load for unit image failed: " + imagePath);
            }

            int[] skillIds = rawData.skills;

            List<Skill> skills = new List<Skill>();
            foreach (int skillId in skillIds) 
            {
                Skill skill = SkillFactory.getInstance().getSkill(skillId);
                if (skill == null)
                {
                    throw new Exception("Resource load for unit skill failed: " + name + ", skill id:" + skillId);
                } else
                {
                    skills.Add(skill);
                }
            }

            return new Unit(name, image, skills, id);
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return null;
        }
    }
}
