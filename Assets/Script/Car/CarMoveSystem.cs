using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider LeftWheel;
    public WheelCollider RightWheel;
    public bool b_Motor;
    public bool b_Steering;

}
public class CarMoveSystem : MonoBehaviour
{
    public List<AxleInfo> AxleInfos;
    public float MaxMotor;
    public float MaxSteer;
    public float BreakForce;

    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void MovedCar(float motorTorque, float steering, bool bIsBreak)
    {
        motorTorque *= MaxMotor;
        steering *= MaxSteer;

        foreach (AxleInfo axleInfo in AxleInfos)
        {
            if (axleInfo.b_Steering)
            {
                axleInfo.LeftWheel.steerAngle = steering;
                axleInfo.RightWheel.steerAngle = steering;
            }
            if (axleInfo.b_Motor)
            {
                axleInfo.LeftWheel.motorTorque = motorTorque;
                axleInfo.RightWheel.motorTorque = motorTorque;
            }

            float _break = (bIsBreak ? 1 : 0);

            axleInfo.LeftWheel.brakeTorque = BreakForce * _break;
            axleInfo.RightWheel.brakeTorque = BreakForce * _break;

            ApplyLocalPositionToVisuals(axleInfo.LeftWheel);
            ApplyLocalPositionToVisuals(axleInfo.RightWheel);
        }
    }

}
