using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject PlayerObj;

    public Transform WayPoints;

    public AIEnemySpawner _AIEnemySpawner;
    public ItemManager _ItemManager;
    public UIManager _UIManager;

    public float StartTimes;
    public float CurrentRoundTime;
    public bool bTimeMove = true;

    public GameObject[] PartObj;

    public GameObject ShopUI;
    public GameObject PlayerUI;

    public bool IsMove = true;

    private void Awake()
    {   
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _AIEnemySpawner = GetComponent<AIEnemySpawner>();
        _ItemManager = GetComponent<ItemManager>();
        _UIManager = GetComponent<UIManager>();
        _AIEnemySpawner.StartCoroutine("SpawnEnemy");
        RaceStart();
        ResetTimer();

    }

    private void Update()
    {
        _UIManager.MoveNeedle();
        RecordTimeStart();
        _UIManager.AddPartsIcon();

    }

    public PlayerController Player() { return PlayerObj.GetComponent<PlayerController>(); }

    public void RaceStart()
    {
        _ItemManager.StartItemSpawn();
        PlayerUI.SetActive(true);
        StartTime();
        _UIManager.StartCoroutine("CountdownToStart");
        RecordTimeStart();
    }

    public void RaceEnd()
    {
        RecordTimeEnd();
        StopTIme();
        PlayerUI.SetActive(false);
        _UIManager.ActiveGameOverUI();
    }

    public void RecordTimeStart()
    {
       CurrentRoundTime = Time.time - StartTimes;
    }

    public void RecordTimeEnd()
    {
        GameInstance.Instance.RaceClearTime += CurrentRoundTime;
    }
    
    public void ResetTimer()
    {
        StartTimes = Time.time;
    }

    public void StopTIme()
    {
        bTimeMove = !bTimeMove;
        Time.timeScale = Convert.ToInt32(bTimeMove);
    }

    public void StartTime()
    {
        bTimeMove = true;
        Time.timeScale = Convert.ToInt32(bTimeMove);
    }
    public void GoShopItemActive()
    {
        PlayerUI.SetActive(false);
        ShopUI.SetActive(true);
        StopTIme();
    }
    public void ReStartGame()
    {
        StartTime();

        ShopUI.SetActive(false);
        PlayerUI.SetActive(true);

        Player().AddParts();
        _UIManager.AddPartsIcon();
    }

}
