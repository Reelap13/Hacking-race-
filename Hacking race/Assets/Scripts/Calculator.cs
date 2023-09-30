using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calculator
{
    public static Vector3 GetPositionBetweenTwoObjects(Transform first, Transform second)
    {
        Vector3 start = first.position;
        Vector3 end = second.position;

        return (end + start) / 2;
    }

    public static Vector3 GetDistanceBetweenTwoObjects(Transform first, Transform second)
    {
        Vector3 start = first.position;
        Vector3 end = second.position;

        return end - start;
    }

    public static Vector3 GetDirectionalVectorFromOneToOtherObject(Transform first, Transform second)
    {
        return GetDistanceBetweenTwoObjects(first, second).normalized;
    }

    public static float GetAngleOfRotationToDirectionVector(Vector3 direction)
    {
        return Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI;
    }
}
