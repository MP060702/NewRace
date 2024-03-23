using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityWheel : BasePart
{
    public override void GetPart(int needMoney)
    {
        base.GetPart(needMoney);
        Debug.Log("CityWheel");
    }
}
