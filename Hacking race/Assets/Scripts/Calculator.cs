using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calculator
{
    public static Vector3 GetPositionBetweenTwoObjects(Transform first, Transform second)
    {
        return GetPositionBetweenTwoPosition(first.position, second.position);
    }
    public static Vector3 GetPositionBetweenTwoPosition(Vector3 start, Vector3 end)
    {
        return (end + start) / 2;
    }

    public static Vector3 GetDistanceBetweenTwoObjects(Transform first, Transform second)
    {
        return GetDistanceBetweenTwoPosition(first.position, second.position);
    }
    public static Vector3 GetDistanceBetweenTwoPosition(Vector3 start, Vector3 end)
    {
        return end - start;
    }

    public static Vector3 GetDirectionalVectorFromOneToOtherObject(Transform first, Transform second)
    {
        return GetDirectionalVectorFromOneToOtherPosition(first.position, second.position);
    }
    public static Vector3 GetDirectionalVectorFromOneToOtherPosition(Vector3 first, Vector3 second)
    {
        return GetDistanceBetweenTwoPosition(first, second).normalized;
    }

    public static float GetAngleOfRotationToDirectionVector(Vector3 direction)
    {
        return Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
    }

    public static float CalculateAngle(float a, float b)
    {
        return Mathf.Min(Mathf.Abs(a - b - 360) % 360, 360 - Mathf.Abs(a - b - 360) % 360);
    }
}
