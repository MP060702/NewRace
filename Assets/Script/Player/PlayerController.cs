using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{   
    [HideInInspector] 
    public Rigidbody _rigidBody;
    private CarMoveSystem _carMoveSystem;

    public Transform WayPoints;
    public int WayIndex;
    [HideInInspector] public float DefaultMaxMotor;

    [HideInInspector] 
    public Transform TargetPoint;

    [HideInInspector]
    public bool CanTouchFinishLine = false;

    public GameObject Danger;
    public bool ActiveWheel = false;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _carMoveSystem = GetComponent<CarMoveSystem>();
        DefaultMaxMotor = _carMoveSystem.MaxMotor;
        TargetPoint = WayPoints.GetChild(WayIndex);
        AddParts();
    }

    private void FixedUpdate()
    {
        MoveInputSystem();

        if (Vector3.Distance(TargetPoint.position, transform.position) <= 30)
        {   
            if (WayPoints.childCount > WayIndex)
            {
                WayIndex++;
            }    

            if (WayIndex == WayPoints.childCount)
            {
                WayIndex = 0;
                CanTouchFinishLine = true;
            }

            TargetPoint = WayPoints.GetChild(WayIndex);
        }
    }

    private void Update()
    {
        
    }

    void MoveInputSystem()
    {
        float motorTorque = Input.GetAxis("Vertical");
        float steering = Input.GetAxis("Horizontal");
        bool b_break = Input.GetKey(KeyCode.Space);

        _carMoveSystem.MovedCar(motorTorque, steering, b_break);
    }

    public void SetMotorSpeed(float motorSpeed)
    {
        _carMoveSystem.MaxMotor = motorSpeed;
    }

    public void AddParts()
    {   
        for(int i = 0; i < GameInstance.Instance.PartsData.Count; i++)
        {
            for(int j = 0; j < GameManager.Instance.PartObj.Length; j++)
            {
                if (GameInstance.Instance.PartsData[i] == GameManager.Instance.PartObj[j].name)
                {
                    GameObject Parts = Instantiate(GameManager.Instance.PartObj[j], transform.position, transform.rotation);
                    Parts.transform.parent = this.transform;
                }                             
            }
        }
    }
    

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<BaseItem>())
        {
            BaseItem item = collision.gameObject.GetComponent<BaseItem>();
            string itemObjName = collision.gameObject.name.Substring(0, collision.gameObject.name.Length - 7);
            GameManager.Instance._UIManager.MarkItems(itemObjName);
            item.OnGetItem(this);
            Destroy(collision.gameObject);
        }
        
        if(collision.gameObject.name == "FinishLine" && CanTouchFinishLine == true)
        {
            GameManager.Instance._UIManager.PlayerLaps += 1;
        }

        if (collision.gameObject.tag == "SlowObj" && ActiveWheel == false)
        {
            _carMoveSystem.MaxMotor = 250f;
            Debug.Log("Slowed");
        }
    }

    public void OnTriggerExit(Collider collision)
    {

        if (collision.gameObject.tag == "SlowObj")
        {
            _carMoveSystem.MaxMotor = 1000f;
        }
    }

    public void WarningEnemy(GameObject enemyTarget)
    {
        GameObject warningObj = Instantiate(Danger, transform.position, Quaternion.identity);
        warningObj.transform.parent = this.transform;
        Warning warningInfo = warningObj.GetComponent<Warning>();
        warningInfo.Target = enemyTarget;
    }

}