using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnitInfo : MonoBehaviour, IPointerExitHandler
{
    public float width = 200;
    public float height = 300;
    public float padding = 0;
    private Unit unit;
    private Transform skillInfoContent;
    private List<GameObject> skillInfos = null;

    public void setUnitInfo(Unit unit, Vector3 position)
    {
        RectTransform rect = transform.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(width, height);

        transform.Find("Panel").Find("Name").GetComponent<Text>().text = unit.name;
        transform.Find("Panel").Find("Image").GetComponent<Image>().sprite = unit.image;
        transform.position = normalizePosition(position);
        skillInfoContent = transform.Find("Panel").Find("SkillBoard").Find("Scroll View").Find("Viewport").Find("Content");
        clearSkillInfos();
        unit.loopSkills(setSkillInfos);
    }

    public Vector3 normalizePosition(Vector3 position)
    {
        float currentX = position.x;
        float currentY = position.y;
        float xLeftPositionLimit = width/2 + padding;
        float xRightPositionLimit = Screen.width - width/2 - padding;
        float yTopPositionLimit = Screen.height - height/2 - padding;
        float yBottomPositionLimit = height/2 + padding;

        if (position.x < xLeftPositionLimit) 
        {
            currentX = xLeftPositionLimit;
        } else if (position.x > xRightPositionLimit)
        {
            currentX = xRightPositionLimit;
        }

        if (position.y > yTopPositionLimit)
        {
            currentY = yTopPositionLimit;
        } else if (position.y < yBottomPositionLimit)
        {
            currentY = yBottomPositionLimit;
        }
        
        return new Vector3(currentX, currentY, position.z);
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
    public void OnPointerExit(PointerEventData eventData)
    {
        setActive(false);
    }
}
