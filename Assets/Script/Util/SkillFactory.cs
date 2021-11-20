using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillFactory 
{
    private const string DEFAULT_METAFILE_PATH = "Metafile/Skill/";
    private const string DEFAULT_IMAGE_PATH = "Images/Skill/";

    public static Dictionary<int, Skill> skillDictionary;
    public static SkillFactory skillFactory = null;
    public static SkillFactory getInstance()
    {        
        if (skillFactory == null)
        {
            skillFactory = new SkillFactory();
        }
        return skillFactory;
    }

    [Serializable]
    public class SkillRawData
    {
        public string name;
        public string image;
        public string text;
        public int id;
    }

    public Skill getSkill(int id)
    {
        if (skillDictionary == null)
        {
            skillDictionary = new Dictionary<int, Skill>();
        }
        if (skillDictionary.ContainsKey(id))
        {
            return skillDictionary[id];
        } else
        {
            return null;
        }
    }
    public void loadAllSkills()
    {
        try
        {
            TextAsset[] data = Resources.LoadAll<TextAsset>(DEFAULT_METAFILE_PATH);
            if (data == null)
            {
                throw new Exception("Resource load for skill meta file failed: " + DEFAULT_METAFILE_PATH);
            }
            foreach (TextAsset t in data)
            {
                Skill skill = readSkillFromMetafile(t);
                if (skillDictionary == null)
                {
                    skillDictionary = new Dictionary<int, Skill>();
                }
                if (skillDictionary.ContainsKey(skill.id)) 
                {
                    throw new Exception("Skill id[" + skill.id + "] is duplicated: " + skill.name);
                } else
                {
                    skillDictionary.Add(skill.id, skill);
                }
            }
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    private Skill readSkillFromMetafile(TextAsset data)
    {
        try
        {
            SkillRawData rawData = JsonUtility.FromJson<SkillRawData>(data.ToString());
            Skill skill = getSkill(rawData);
            return skill;
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return null;
        }
    }

    private Skill getSkill(SkillRawData rawData)
    {
        try
        {
            string name = rawData.name;
            string imagePath = DEFAULT_IMAGE_PATH + rawData.image;
            string text = rawData.text;
            int id = rawData.id;
            Sprite image = Resources.Load<Sprite>(imagePath);
            if (image == null)
            {
                throw new Exception("Resource load for skill image failed: " + imagePath);
            }
            return new Skill(name, text, image, id);
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
            return null;
        }
    }
}
