using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int mapSize = 5;
    public List<Unit> units;
    private TileMap tileMap = null;
    
    void Start()
    {
        tileMap = new TileMap(mapSize);
        units = new List<Unit>();

        initializeTileMap();

        // TestCodes
        addUnit("Climber", 1, 1);
        addUnit("Fencer", 2, 3);
        addUnit("Cyclist", 3, 4);
    }

    void initializeTileMap()
    {
        tileMap.currentTileMapSize = mapSize;
        tileMap.createAndResetMap();
        TileMapUI.getInstance().setTileMapUI(tileMap);
    }

    void addUnit(string name, int x, int y)
    {
        addUnit(UnitFactory.getInstance().get(name), tileMap.getTile(x, y));
    }

    void addUnit(Unit unit, Tile tile)
    {
        if (tile != null)
        {
            tile.setUnit(unit);
        }
        units.Add(unit);
    }
}
