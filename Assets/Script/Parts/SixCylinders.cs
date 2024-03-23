using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixCylinders : BasePart
{
    public override void GetPart(int needMoney)
    {
        base.GetPart(needMoney);
        Debug.Log("Six Cylinders");
    }
}
