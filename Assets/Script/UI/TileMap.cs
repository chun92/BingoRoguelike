using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public const float padding = 0;
    private float tileWidth;
    private float tileHeight;


    public int currentTileMapSize = 1;
    
    private Dictionary<Vector2Int, Tile> tiles;

    void Start()
    {
        tiles = new Dictionary<Vector2Int, Tile>();
        createTileMap(currentTileMapSize);
    }


    public void setTileMapSize(int size) 
    {
        currentTileMapSize = size;
    }

    public void createTileMap(int size)
    {
        int idCount = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                createTile(idCount, i, j, size);
                idCount++;
            }
        }
        
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(tileWidth * size + padding * (size - 1), tileHeight * size + padding * (size - 1));
    }

    public void createTile(int id, int x, int y, int num) 
    {
        GameObject tileObject = (GameObject) Instantiate(ResourceManager.tilePrefab, transform);
        Tile tile = new Tile(id, x, y, num, null);
        TileUI tileUI = tileObject.GetComponent<TileUI>();
        Vector2 size = tileUI.setTileUI(tile);
        tileWidth = size.x;
        tileHeight = size.y;

        tiles.Add(new Vector2Int(x, y), tile);
    }

    public Tile getTileWithPosition(int x, int y)
    {
        return tiles[new Vector2Int(x, y)];
    }
}
