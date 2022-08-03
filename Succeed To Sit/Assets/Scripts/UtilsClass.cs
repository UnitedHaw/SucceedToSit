using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsClass
{
    public static Vector3 GetRandomDir()
    {
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }
    public static float GetAngleFromVector(Vector3 vector)
    {
        float radians = Mathf.Atan2(vector.y, vector.x);
        float degrees = radians * Mathf.Rad2Deg;
        return degrees;
    }
    public static Transform GetRandomTargetPoint()
    {
        var targetPointList = TrainData.Instance.GetRandomTargetPoint();
        return targetPointList[Random.Range(0, targetPointList.Count)];
    }

}
