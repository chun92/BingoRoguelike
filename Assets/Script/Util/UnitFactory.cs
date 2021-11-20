using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory
{    
    private const string DEFAULT_PATH = "Resources/Images/Unit";
    public static UnitFactory unitFactory = null;
    public static UnitFactory getInstance()
    {        
        if (unitFactory == null)
        {
            unitFactory = new UnitFactory();
        }
        return unitFactory;
    }

    //
}
