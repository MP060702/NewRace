using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Progress;

public class BasePart : MonoBehaviour
{
    public virtual void GetPart(int needMoney)
    {
       string partData = gameObject.name;
        if (GameInstance.Instance.Money >= needMoney)
        {
            if (GameInstance.Instance.PartsData.Contains(partData) == false)
            {
                GameInstance.Instance.Money -= needMoney;
                Debug.Log(GameInstance.Instance.Money);
                GameInstance.Instance.PartsData.Add(partData);
                Debug.Log("Add : " + partData);
            }
        }
    }
}
