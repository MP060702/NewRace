using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{   
    public static GameInstance Instance;
    public List<string> PartsData = new List<string>();
    public int Money = 0;
    public int Stage = 0;
    public float RaceClearTime;
    public List<float> Ranks = new List<float>() { 0, 0, 0, 0, 0 };


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddRank()
    {
        Ranks.Add(RaceClearTime);
        Ranks.Sort();
        Ranks.Reverse();

        if(Ranks.Count > 5 ) 
        {
            Ranks.RemoveAt(Ranks.Count - 1);
        }
        
        RaceClearTime = 0;
    }
}
