using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankingManager : MonoBehaviour
{
    public TextMeshProUGUI Rankings;

    public void Start()
    {
        string[] temp = { "1st : ", "2nd : ", "3rd : ", "4th : ", "5th : " };

        for (int i = 0; i < GameInstance.Instance.Ranks.Count; i++)
        {
            temp[i] += GameInstance.Instance.Ranks[i];
        }

        Rankings.text = string.Join("\n", temp);
    }


}
