using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DesertWheel : BasePart
{
    public override void GetPart(int needMoney)
    {   
        base.GetPart(needMoney);
        Debug.Log("DesertWheel");
    }
}
