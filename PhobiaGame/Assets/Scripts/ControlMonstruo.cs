using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlMonstruo : MonoBehaviour
{
    NavMeshAgent agenteNavMesh;
    public Transform objetivo;
    private bool perseguir;

    void Start()
    {
        agenteNavMesh = GetComponent<NavMeshAgent>();
        perseguir = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(perseguir)
            agenteNavMesh.destination = objetivo.position;
    }

    public void EmpezarPersecucion()
    {
        perseguir = true;
    }
}
