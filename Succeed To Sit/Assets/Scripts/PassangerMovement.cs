using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PassangerMovement : MonoBehaviour
{

    public Transform targetPoint;
    public LayerMask seatsLayer;

    private NavMeshAgent agent;
    private RaycastHit hit;
    private float rayDistance = 5f;
    private bool OnSit;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);

        if (Input.GetKeyDown(KeyCode.T))
        {
            CharacterSitDown();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform == targetPoint.gameObject.transform)
        {
            agent.isStopped = true;
            Debug.Log("On Sit!");
        }
    }

    private void CharacterSitDown()
    {
        if (targetPoint != null)
        {
            transform.position = targetPoint.position;
            transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
            OnSit = true;    
        }
    }
}
