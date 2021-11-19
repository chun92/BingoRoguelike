using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfo : MonoBehaviour
{
    private Unit unit;
    
    private Object skillInfoPrefab;
    private Transform skillInfoContent;

    public void setUnitInfo(Unit unit)
    {        
        transform.Find("Panel").Find("Name").GetComponent<Text>().text = unit.name;
        transform.Find("Panel").Find("Image").GetComponent<Image>().sprite = unit.image;
        unit.loopSkills(setSkillInfos);
    }

    public void setActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void setSkillInfos(Skill skill, int index)
    {
        skillInfoPrefab = Resources.Load("Prefabs/UI/SkillInfo");
        skillInfoContent = transform.Find("Panel").Find("SkillBoard").Find("Scroll View").Find("Viewport").Find("Content");
        GameObject skillInfoObject = (GameObject) Instantiate(skillInfoPrefab, skillInfoContent);
        skillInfoObject.GetComponent<SkillInfo>().setSkillInfo(skill, index);
    }
}
