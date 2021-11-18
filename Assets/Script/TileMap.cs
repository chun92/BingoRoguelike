using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    public const float padding = 0;
    private float tileWidth;
    private float tileHeight;


    public int currentTileMapSize = 1;
    private Object tilePrefab;
    private GridLayout gridLayout;
    
    private Dictionary<Vector2Int, Tile> tileInfo;

    // Start is called before the first frame update
    void Start()
    {
        tilePrefab = Resources.Load("Prefabs/tile");
        gridLayout = gameObject.GetComponent<GridLayout>();
        tileInfo = new Dictionary<Vector2Int, Tile>();
        createTileMap(currentTileMapSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTileMapSize(int size) 
    {
        currentTileMapSize = size;
    }

    public void createTileMap(int size)
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                createTile(i, j, size);
            }
        }
        
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(tileWidth * size + padding * (size - 1), tileHeight * size + padding * (size - 1));
    }

    public void createTile(int x, int y, int num) 
    {
        GameObject tileObject = (GameObject) Instantiate(tilePrefab, transform);
        Tile tile = tileObject.GetComponent<Tile>();
        Vector2 size = tile.setTilePosition(x, y, num);
        tileWidth = size.x;
        tileHeight = size.y;

        tileInfo.Add(new Vector2Int(x, y), tile);
    }

    public Tile getTileWithPosition(int x, int y)
    {
        return tileInfo[new Vector2Int(x, y)];
    }
}
