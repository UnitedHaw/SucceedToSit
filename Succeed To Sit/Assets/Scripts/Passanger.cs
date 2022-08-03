using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Passanger  : MonoBehaviour
{
    public static Passanger Create(Vector3 position)
    {
        Transform passangerTranform = Instantiate(GameAssets.Instance.pfPassangerNPC, position, Quaternion.identity);
        Passanger passangerNPC = passangerTranform.GetComponent<Passanger>();

        return passangerNPC;
    }

    [SerializeField] private LayerMask seatPointLayer;
    private Transform targetPoint;
    private NavMeshAgent agent;
    private float minDistonationToTargetPoint = 1f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        targetPoint = UtilsClass.GetRandomTargetPoint();

        if (targetPoint != null)
        {
            agent.isStopped = false;
            agent.destination = targetPoint.position;
        }
    }

    private void Update()
    {
        //transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
        agent.stoppingDistance = 1f;

        Debug.DrawRay(transform.position, transform.forward * 10f, Color.blue);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == targetPoint.transform)
        {
            Debug.Log("Тык");
            agent.isStopped = true;
            Collider[] seatPointArray = Physics.OverlapSphere(transform.position, 7f, seatPointLayer);
            Debug.Log(seatPointArray.Length);
            if (seatPointArray.Length > 0)
            {
                int seatIndex = Random.Range(0, seatPointArray.Length - 1);
                Transform seatTransform = seatPointArray[seatIndex].gameObject.transform;
                SitOn(seatTransform);
                Debug.Log("Хочу сесть на " + seatIndex);
            }
        }
    }
    private void SitOn(Transform seatPoint)
    {
        if (seatPoint != null)
        {
            transform.position = seatPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 6f);
    }
}
