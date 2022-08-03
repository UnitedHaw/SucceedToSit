using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainData : MonoBehaviour
{
    public static TrainData Instance { get; private set; }

    [SerializeField] private List<Transform> vanSeatTargerPoint;
    private float offsetAmount;
    private Transform targetPoint;

    private void Awake()
    {
        Instance = this;

        targetPoint = transform.Find("targetPoint");

        for(int i = 0; i < 12; i++)
        {
            offsetAmount += 6f;
            Transform currentPoint = Instantiate(targetPoint, new Vector3(
                targetPoint.position.x, targetPoint.position.y, targetPoint.position.z + offsetAmount),
                Quaternion.identity);
            vanSeatTargerPoint.Add(currentPoint);
        }       
    }

    public List<Transform> GetRandomTargetPoint()
    {
        return vanSeatTargerPoint;
    }
}
