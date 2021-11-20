using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int mapSize = 5;
    private TileMap tileMap = null;
    // Start is called before the first frame update
    void Start()
    {
        tileMap = new TileMap(mapSize);

        // XXX: temporally test code
        Unit testUnit1 = new Unit("Hero", Resources.Load<Sprite>("Images/RubberDuck"));
        testUnit1.addSkill(new Skill("umbrella", "shild!!", Resources.Load<Sprite>("Images/Umbrella"), 1));

        
        Unit testUnit2 = new Unit("Dark Hero", Resources.Load<Sprite>("Images/Cat"));
        testUnit2.addSkill(new Skill("snipe1", "I will kill you!!", Resources.Load<Sprite>("Images/Snipe"), 2));
        testUnit2.addSkill(new Skill("shift", "Help ME!", Resources.Load<Sprite>("Images/Shift"), 2));
        
        initializeTileMap();

        addUnit(testUnit1, tileMap.getTile(1, 1));
        addUnit(testUnit2, tileMap.getTile(2, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void initializeTileMap()
    {
        tileMap.currentTileMapSize = mapSize;
        tileMap.createAndResetMap();
        TileMapUI.getInstance().setTileMapUI(tileMap);
    }

    void addUnit(Unit unit, Tile tile)
    {
        tile.setUnit(unit);
    }
}
