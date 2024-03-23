using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainWheel : BasePart
{
    public override void GetPart(int needMoney)
    {
        base.GetPart(needMoney);
        Debug.Log("MountainWheel");
    }
}
 