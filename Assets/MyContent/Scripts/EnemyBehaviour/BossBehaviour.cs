using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossBehaviour : MonoBehaviour
{

    [SerializeField]
    private Transform target; // Allows specification of object to be followed in inspector

    Rigidbody rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();


    }

 

    // FOR FIELD OF VIEW!!! //
    void Update()
    {

        transform.LookAt(target); // Rotate enemies to face player character



    }

  

  
}


