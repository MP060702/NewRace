using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoShopItem : BaseItem
{
    public override void OnGetItem(PlayerController player)
    {
        base.OnGetItem(player);
        GameManager.Instance.GoShopItemActive();
    }
}
