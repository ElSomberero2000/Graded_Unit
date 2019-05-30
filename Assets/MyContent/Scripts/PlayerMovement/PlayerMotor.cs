using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    private Animator animator;
    private bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RunAnimToggle(); // Animation control
        
        if (target != null)
        {
            agent.SetDestination(target.position); // Makes the player run towards a targetted object
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point); // Makes the player run to a point clicked in the level where the nav mesh allows.
    }

    private void RunAnimToggle()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) // Plays the idle animation when the targeted destination is reached
        {
            // Transition to idle anim
            running = false;
        }
        else // If an area on the level is clicked the player actor runs to that location
        {
            // Transition to run anim
            running = true;
        }
        animator.SetBool("running", running);
    }

    public void FollowTarget (Interactable newTarget) // If selecting a moving object the player will focus on the target and move/turn to face it
    {
        agent.stoppingDistance = newTarget.radius * 0.8f;
        agent.updateRotation = false;
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget() // If clicked elsewhere will lose focus on the last target 
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    public void FaceTarget() // Code that makes the actor to face the target
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
