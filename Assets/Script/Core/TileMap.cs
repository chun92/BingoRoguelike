using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap
{
    public int currentTileMapSize { get; set; }
    
    public Dictionary<Vector2Int, Tile> tiles { get; }

    public TileMap(int size)
    {
        currentTileMapSize = size;
        tiles = new Dictionary<Vector2Int, Tile>();
    }

    public void createAndResetMap()
    {
        tiles.Clear();

        int idCount = 0;
        for (int i = 0; i < currentTileMapSize; i++)
        {
            for (int j = 0; j < currentTileMapSize; j++)
            {
                Tile tile = new Tile(idCount, i, j, currentTileMapSize, null);
                tiles.Add(new Vector2Int(i, j), tile);
                idCount++;
            }
        }
    }

    public Tile getTile(int x, int y)
    {
        Vector2Int key = new Vector2Int(x, y);
        if (tiles.ContainsKey(key))
        {
            return tiles[key];
        } else
        {
            return null;
        }
    }
}
