using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public int id { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int tileNumInMap { get; set; }
    public Unit unit { get; set; }
    // Start is called before the first frame update
    public Tile(int id, int x, int y, int tileNumInMap, Unit unit)
    {
        this.id = id;
        this.x = x;
        this.y = y;
        this.tileNumInMap = tileNumInMap;
        this.unit = unit;
        // XXX: temporally test code
        this.unit = new Unit("Hero", Resources.Load<Sprite>("Images/RubberDuck"));
        this.unit.addSkill(new Skill("umbrella", "shild!!", Resources.Load<Sprite>("Images/Umbrella"), 1));
    }
}
