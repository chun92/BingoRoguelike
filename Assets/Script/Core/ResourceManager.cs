using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    static public Object skillInfoPrefab { set; get; }
    static public Object tilePrefab { set; get; }
    // Start is called before the first frame update
    void Start()
    {
        skillInfoPrefab = Resources.Load("Prefabs/UI/SkillInfo");
        tilePrefab = Resources.Load("Prefabs/tile");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
