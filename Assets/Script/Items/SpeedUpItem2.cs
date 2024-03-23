using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem2 : BaseItem
{   
    public override void OnGetItem(PlayerController player)
    {   
        player.StartCoroutine(SpeedUp(player));
    }

    IEnumerator SpeedUp(PlayerController player)
    {   
        player.SetMotorSpeed(player.DefaultMaxMotor + 200f);
        yield return new WaitForSeconds(5f);
        player.SetMotorSpeed(player.DefaultMaxMotor);

    }

}
