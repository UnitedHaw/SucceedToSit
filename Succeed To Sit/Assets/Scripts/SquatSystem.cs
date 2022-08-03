using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquatSystem : MonoBehaviour
{
    public static bool OnSit { get; private set; }

    [SerializeField] private LayerMask objectSelectionMask;
    [SerializeField] private float rayDistance;
    private Transform seatTarget;
    private Vector3 playerPositionBeforeSit;
    private RaycastHit hit;
    
    void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);

        if (Physics.Raycast(ray, out hit, rayDistance, objectSelectionMask) != false)
        {
            //Debug.Log(hit.collider.name);
            seatTarget = hit.collider.transform;

            PlayerUI.Instance.ShowHint();
        }
        else
        {
            seatTarget = null;
            PlayerUI.Instance.HideHint();
        }

        if(Input.GetKeyDown(KeyCode.Space) && seatTarget != null && OnSit == false)
        {
            playerPositionBeforeSit = transform.position;
            CharacterSitDown();
        }
        if(Input.GetKeyDown(KeyCode.T) && OnSit != false)
        {
            transform.position = playerPositionBeforeSit;
            OnSit = false;
        }
            
    }
    private void CharacterSitDown()
    {
        if(seatTarget != null)
        {
            transform.position = seatTarget.transform.position;
            transform.rotation *= Quaternion.Euler(0f, 180f, 0f);
            OnSit = true;
        }
    }
}
