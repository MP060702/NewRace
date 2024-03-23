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

    public float _startTime = 0;
    public float _endTime = 0;
    public float RaceClearTime;
    public bool bTimeMove = true;

    public GameObject[] PartObj;

    public GameObject ShopUI;
    public GameObject PlayerUI;

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
    }

    public void RecordTimeStart()
    {
        _startTime = Time.time;
    }

    public void RecordTimeEnd()
    {
        _endTime = Time.time;
        RaceClearTime = _endTime - _startTime;
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