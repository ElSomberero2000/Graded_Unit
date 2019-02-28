using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private Transform target; // Allows specification of object to be followed in inspector
    [SerializeField]
    private Transform transform; // Allows specification of object to be adjusted in inspector

    private bool running = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    private void Chase() // TODO: Generate patrol routes that enemies will follow when player is undetected
                         // TODO: Give enemies sight so player can be detected within cone of vision whilst stealthed (then begin chase)
    {
        GameObject player =  GameObject.Find("Player"); // Saved target gameobject
        if (player.GetComponent<PlayerMovement>().crouched == false) // Follow player (player is detected)
        {
            running = true; 
            transform.LookAt(target); // Rotate enemies to face player character
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        }
        else if (player.GetComponent<PlayerMovement>().crouched == true) // Remain idle (player is undetected)
        {
            running = false;
        }
        animator.SetBool("running", running);
    }
}
