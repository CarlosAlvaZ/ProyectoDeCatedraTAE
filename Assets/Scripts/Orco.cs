using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orco : MonoBehaviour
{
    public Transform personaje;
    private NavMeshAgent agente;

    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }

    void Update()
    {
        agente.SetDestination(personaje.position);
    }
}
