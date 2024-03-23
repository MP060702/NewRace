using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem3 : BaseItem
{
    public override void OnGetItem(PlayerController player)
    {
        base.OnGetItem(player);
        GameInstance.Instance.Money += 3000;
    }
}
