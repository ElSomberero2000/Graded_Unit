using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// Scene management
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;

    private bool running = false;
    private bool crouched = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        RunAnimToggle();
        Crouched();
    }

    private void Movement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                navMeshAgent.destination = hit.point;
            }

            if (hit.transform.name == "Interactable")
            {
                Debug.Log("Hit interactable");
            }

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
            running = false;
        }
        else
        {
            running = true;
        }
        animator.SetBool("running", running);
    }

    private void Crouched()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            crouched = true;
            Debug.Log("Crouched");
        }
        else crouched = false;
    }
}


