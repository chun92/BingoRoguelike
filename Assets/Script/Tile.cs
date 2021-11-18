using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private int xPoint;
    private int yPoint;
    
    SpriteRenderer boundary;
    SpriteRenderer unit;

    public Tile()
    {
        xPoint = 0;
        yPoint = 0;
    }
    public Tile(int x, int y, int num)
    {
        setTilePosition(x, y, num);
    }

    public Vector2 setTilePosition(int x, int y, int num)
    {
        xPoint = x;
        yPoint = y;

        RectTransform rect = gameObject.GetComponent<RectTransform>();
        SpriteRenderer boundary = transform.Find("Boundary").GetComponent<SpriteRenderer>();

        rect.sizeDelta = boundary.bounds.size;
        rect.position = calculatePosition(x, y, num, boundary.bounds.size);

        return rect.sizeDelta;
    }

    private Vector2 calculatePosition(int x, int y, int num, Vector2 size)
    {
        float width = size.x; 
        float height = size.y;
        float xPosition = -num/2.0f + 0.5f + x;
        float yPosition = -num/2.0f + 0.5f + y;
        return new Vector2(xPosition * (width + TileMap.padding), yPosition * (height + TileMap.padding));
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        unit.color = Color.green;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        unit.color = Color.white;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        unit.color = Color.cyan;
    }

    void Start()
    {
        addPhysics2DRaycaster();
        boundary = transform.Find("Boundary").GetComponent<SpriteRenderer>();
        unit = transform.Find("Boundary").Find("Unit").GetComponent<SpriteRenderer>();
    }
    
    private void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
}
