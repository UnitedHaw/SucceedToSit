using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private Transform passangerSpawnPosition;
    [SerializeField] private int passangerAmount;
    private Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = passangerSpawnPosition.position;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            while(passangerAmount != 0)
            {
                Passanger.Create(spawnPosition + UtilsClass.GetRandomDir() * Random.Range(0f, 5f));
                passangerAmount--;
            }  
        }
    }
}
