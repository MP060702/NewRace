using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ForwardDashAI : MonoBehaviour
{
    private CarMoveSystem carMoveSystem;

    public Transform TargetPoint;
    public int WayIndex;

    private void Start()
    {
        carMoveSystem = GetComponent<CarMoveSystem>();
        transform.LookAt(GameManager.Instance.Player().transform.position);
        TargetPoint = GameManager.Instance.WayPoints.GetChild(WayIndex);
    }

    private void Update()
    {
        FoundPlayer();
        FoundWayPoint();
        MovedAI();
    }

    public void MovedAI()
    {
        Vector3 wayPointDistance = transform.InverseTransformPoint(TargetPoint.position);
        wayPointDistance = wayPointDistance.normalized;

        carMoveSystem.MovedCar(1, wayPointDistance.x, false);
    }

    public void FoundWayPoint()
    {
        if (Vector3.Distance(TargetPoint.position, transform.position) <= 30)
        {
            if (GameManager.Instance.WayPoints.childCount > WayIndex)
            {
                WayIndex++;
            }

            if (WayIndex == GameManager.Instance.WayPoints.childCount)
            {
                WayIndex = 0;
            }

            TargetPoint = GameManager.Instance.WayPoints.GetChild(WayIndex);
        }
    }

    public void FoundPlayer()
    {
        if (Vector3.Distance(GameManager.Instance.Player().transform.position, transform.position) <= 100)
        {
            Vector3 playerDir = GameManager.Instance.Player().transform.position - transform.position;
            float lookRotationSpeed = 3f;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(playerDir), Time.deltaTime * lookRotationSpeed);
        }
    }
}