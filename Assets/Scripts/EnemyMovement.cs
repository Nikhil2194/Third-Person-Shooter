using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Detection detection;

    private Transform target;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        detection = GetComponent<Detection>();
        detection.OnAggro += Detection_OnAggro;
    }

    private void Detection_OnAggro(Transform target)
    {
        this.target = target;
       
    }


    private void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.transform.position);
            float currentspeed = navMeshAgent.velocity.magnitude;
            animator.SetFloat("Speed", currentspeed);
        }

    }
}