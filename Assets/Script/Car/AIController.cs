using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIController : MonoBehaviour
{   
    private CarMoveSystem carMoveSystem;

    public Transform WayPoints;
    public int WayIndex = 0;

    //[HideInInspector]
    public Transform TargetPoint;

    [HideInInspector]
    public bool AICanTouchFinishLine = false;

    private void Start()
    {   
        carMoveSystem = GetComponent<CarMoveSystem>();

        TargetPoint = WayPoints.GetChild(WayIndex);
    }

    private void FixedUpdate()
    {   
        FoundWayPoint();
        MoveAI();
    }

    public void MoveAI()
    {
        Vector3 wayPointDistance = transform.InverseTransformPoint(TargetPoint.position);
        wayPointDistance = wayPointDistance.normalized;

        carMoveSystem.MovedCar(1, wayPointDistance.x, false);
    }

    public void FoundWayPoint()
    { 
        if (Vector3.Distance(TargetPoint.position, transform.position) <= 30)
        {
            if (WayPoints.childCount > WayIndex)
            {   
                WayIndex++;
            }

            if (WayIndex == WayPoints.childCount)
            {
                WayIndex = 0;
            }

            TargetPoint = WayPoints.GetChild(WayIndex);
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "FinishLine" && AICanTouchFinishLine == true)
        {
            GameManager.Instance._UIManager.AILaps += 1;
        }
    }
}
