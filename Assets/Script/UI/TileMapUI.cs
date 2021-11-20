using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapUI : MonoBehaviour
{
    public const float padding = 0;
    private float tileWidth;
    private float tileHeight;

    private static TileMapUI tileMapUI = null;

    public static TileMapUI getInstance()
    {
        if (tileMapUI == null)
        {
            tileMapUI = GameObject.FindGameObjectWithTag("TileMap").GetComponent<TileMapUI>();
        }
        return tileMapUI;
    }

    public void setTileMapUI(TileMap tileMap)
    {
        createTileMap(tileMap.currentTileMapSize, tileMap.tiles);
    }

    public void createTileMap(int size, Dictionary<Vector2Int, Tile> tiles)
    {
        foreach(KeyValuePair<Vector2Int, Tile> item in tiles)
        {
            Vector2Int pos = item.Key;
            Tile tile = item.Value;
            createTile(tile, pos.x, pos.y, size);
        }
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(tileWidth * size + padding * (size - 1), tileHeight * size + padding * (size - 1));
    }

    public void createTile(Tile tile, int x, int y, int num) 
    {
        GameObject tileObject = (GameObject) Instantiate(ResourceManager.tilePrefab, transform);
        TileUI tileUI = tileObject.GetComponent<TileUI>();
        Vector2 size = tileUI.setTileUI(tile);
        tileWidth = size.x;
        tileHeight = size.y;
    }
}
