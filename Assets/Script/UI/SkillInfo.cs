using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfo : MonoBehaviour
{

    private int id;
    private const float yDefaultPadding = -0f;
    private const float yDefaultHeight = -35.0f;

    private Skill skill;
    
    public void setSkillInfo(Skill skill, int id)
    {
        setSkillInfo(skill.image, skill.text, id);
    }

    public void setSkillInfo(Sprite image, string text, int id)
    {
        this.id = id;

        transform.Find("Image").GetComponent<Image>().sprite = image;
        transform.Find("Text").GetComponent<Text>().text = text;

        RectTransform rect = transform.GetComponent<RectTransform>();
        Vector3 defaultPosition = rect.position;
        Vector3 newPosition = new Vector3(defaultPosition.x, defaultPosition.y + yDefaultPadding + id * yDefaultHeight, defaultPosition.z);
        rect.position = newPosition;
    }
}
