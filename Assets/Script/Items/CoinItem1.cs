using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem1 : BaseItem
{
    public override void OnGetItem(PlayerController player)
    {
        base.OnGetItem(player);
        GameInstance.Instance.Money += 1000;
    }
}
