using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData
{
    public int unitNo;
    public UnitType unitType;
    public int maxHp;
    public string unitNameKey;
}

[System.Serializable]
public class UnitTableRow
{
    public int unitNo;
    public string unitType;
    public int maxHp;
    public string unitNameKey;
}

public class UnitTable : BaseTable
{
    public override void Parsing(string jsonPath)
    {
        base.Parsing(jsonPath);
    }
}