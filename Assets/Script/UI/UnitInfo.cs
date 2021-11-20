using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfo : MonoBehaviour
{
    private Unit unit;
    private Transform skillInfoContent;
    private List<GameObject> skillInfos = null;

    public void setUnitInfo(Unit unit)
    {        
        transform.Find("Panel").Find("Name").GetComponent<Text>().text = unit.name;
        transform.Find("Panel").Find("Image").GetComponent<Image>().sprite = unit.image;
        skillInfoContent = transform.Find("Panel").Find("SkillBoard").Find("Scroll View").Find("Viewport").Find("Content");
        clearSkillInfos();
        unit.loopSkills(setSkillInfos);
    }

    public void setActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void setSkillInfos(Skill skill, int index)
    {
        GameObject skillInfoObject = (GameObject) Instantiate(ResourceManager.skillInfoPrefab, skillInfoContent);
        skillInfoObject.GetComponent<SkillInfo>().setSkillInfo(skill, index);

        if (skillInfos == null) {
            skillInfos = new List<GameObject>();
        }
        skillInfos.Add(skillInfoObject);
    }

    public void clearSkillInfos()
    {
        if (skillInfos == null) {
            skillInfos = new List<GameObject>();
        }
        foreach(GameObject skill in skillInfos)
        {
            Destroy(skill);
        }
        skillInfos.Clear();
    }
}
