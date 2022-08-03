using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform trainStartPoint;
    [SerializeField] private float trainDestructionPoint;
    private Transform lastVan;

    private void Start()
    {
        lastVan = transform.GetChild(transform.childCount - 1).GetComponent<Transform>();
    }
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        if(lastVan.position.z < trainDestructionPoint)
        {
            gameObject.transform.position = trainStartPoint.position;
        }
    }
}
