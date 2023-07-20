using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCscript : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatisPlayer;
    public Transform player;

    // Roaming
    public Vector3 walkPoint;
    bool walkPointExists;
    public float walkPointRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Roaming();
    }

    private void Roaming()
    {
        if (!walkPointExists) setWalkPoint();
        if (walkPointExists)
            agent.SetDestination(walkPoint);
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointExists = false;
    }
    private void setWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointExists = true;
    }
    // Můj drahý zítřejší Šafíčku, nezapomeň dodělat tyhle 2 zasraný funkce
    // PS: Musíš přidat NavMesh Agentíka a pak to "bejknout" aby věděl co je terén. Hlavně se nenaštvi jinak to nedoděláš <3
    private void AttackPlayer()
    {

    }
    
    private void chasePlayer()
    {

    }
}
