using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivePartsAbility : MonoBehaviour
{
    private string CloneText = "(Clone)";


    public void Update()
    {
        if (GameObject.Find("DesertWheel" + CloneText) != null)
        {
            if(GameInstance.Instance.Stage == 1)
            {
                GameManager.Instance.Player().ActiveWheel = true;
            }
        }

        if(GameObject.Find("MountainWheel" + CloneText) != null)
        {
            if(GameInstance.Instance.Stage == 2)
            {
                GameManager.Instance.Player().ActiveWheel = true;
            }
        }
        
        if (GameObject.Find("CityWheel" + CloneText) != null)
        {
            if(GameInstance.Instance.Stage == 3)
            {
                GameManager.Instance.Player().ActiveWheel = true;
            }
        }

        if(GameObject.Find("6Cylinders" + CloneText) != null)
        {
            if(GameObject.Find("8Cylinders" + CloneText) == null)
            {
                GameManager.Instance.Player().GetComponent<CarMoveSystem>().MaxMotor = 800f;
            }
        }

        if(GameObject.Find("8Cylinders" + CloneText) != null)
        {
            GameManager.Instance.Player().GetComponent<CarMoveSystem>().MaxMotor = 1000f;
        }
    }
}
