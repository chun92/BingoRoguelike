using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceManager : MonoBehaviour
{
    static public Object skillInfoPrefab { set; get; }
    static public Object tilePrefab { set; get; }
    
    // Start is called before the first frame update
    void Start()
    {
        SkillFactory.getInstance().loadAll();
        UnitFactory.getInstance().loadAll();


        skillInfoPrefab = Resources.Load("Prefabs/UI/SkillInfo");
        tilePrefab = Resources.Load("Prefabs/UI/tile");
    
        addPhysics2DRaycaster();
    }
    
    
    private void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
