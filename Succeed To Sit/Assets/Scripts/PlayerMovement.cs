using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(SquatSystem.OnSit == false)
        {
            transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }    
    }
}
