using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // XXX: temporally test code
        Unit testUnit = new Unit("Hero", Resources.Load<Sprite>("Images/RubberDuck"));
        testUnit.addSkill(new Skill("umbrella", "shild!!", Resources.Load<Sprite>("Images/Umbrella"), 1));
        
        TileMap tileMap = new TileMap(5);
        tileMap.createAndResetMap();
        tileMap.getTile(1, 1).unit = testUnit;
        TileMapUI.getInstance().setTileMapUI(tileMap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
