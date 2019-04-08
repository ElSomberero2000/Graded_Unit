using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PMBackup : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    private bool running = false;
    public bool crouched = false;

    public Interactable focus;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); // Click to move system via raycasting
        RunAnimToggle(); // Animation control
        Crouched(); // Stealth mechanic
    }

    private void Movement() // TODO: Remove debug logs (for testing purposes)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                navMeshAgent.destination = hit.point;
            }

            // Check if player clicks on interactable
            if (hit.transform.name == "Interactable")
            {
                Debug.Log("Hit interactable");
            }

            // Check if player clicks on door
            if (hit.transform.name == "Door")
            {
                Debug.Log("Hit door");
            }
        }
    }

    private void RunAnimToggle()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // Transition to idle anim
            running = false;
        }
        else
        {
            // Transition to run anim
            running = true;
        }
        animator.SetBool("running", running);
    }

    private void Crouched() // TODO: Remove debug logs (for testing purposes)
    {
        // If crouched is true then stealth is ongoing else enemies will be aware of player
        if (crouched == false && Input.GetKeyDown(KeyCode.Space))
        {
            crouched = true;
            Debug.Log("Crouched");
        }
        else if (crouched == true && Input.GetKeyDown(KeyCode.Space))
        {
            crouched = false;
            Debug.Log("Uncrouched");
        }
    }
}


