using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileUI : MonoBehaviour, IPointerEnterHandler
{
    private int xPoint;
    private int yPoint;
    
    SpriteRenderer boundary;
    SpriteRenderer unitRenderer;
    
    private Tile tile = null;

    public Vector2 setTileUI(Tile tile)
    {
        this.xPoint = tile.x;
        this.yPoint = tile.y;
        if (tile.unit != null)
        {
            getUnitRenderer().sprite = tile.unit.image;
        }
        this.tile = tile;

        return setTilePosition(tile.x, tile.y, tile.tileNumInMap);
    }

    private Vector2 setTilePosition(int x, int y, int num)
    {
        xPoint = x;
        yPoint = y;

        RectTransform rect = gameObject.GetComponent<RectTransform>();

        rect.sizeDelta = getBoundary().bounds.size;
        rect.position = calculatePosition(x, y, num, getBoundary().bounds.size);

        return rect.sizeDelta;
    }

    private Vector2 calculatePosition(int x, int y, int num, Vector2 size)
    {
        float width = size.x; 
        float height = size.y;
        float xPosition = -num/2.0f + 0.5f + x;
        float yPosition = -num/2.0f + 0.5f + y;
        return new Vector2(xPosition * (width + TileMapUI.padding), yPosition * (height + TileMapUI.padding));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tile.unit != null)
        {
            UnitInfo.getInstance().setUnitInfo(tile.unit, eventData.position);
            UnitInfo.getInstance().setActive(true);
        }
    }

    private SpriteRenderer getUnitRenderer() 
    {
        if (unitRenderer == null)
        {
            unitRenderer = transform.Find("Boundary").Find("Unit").GetComponent<SpriteRenderer>();
        }
        return unitRenderer;
    }

    private SpriteRenderer getBoundary()
    {
        if (boundary == null)
        {
            boundary = transform.Find("Boundary").GetComponent<SpriteRenderer>();
        }
        return boundary;
    }
}
