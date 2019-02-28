using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Scene management
    void OnTriggerEnter(Collider collision)
    {
       // Potential code for collisions with interactables //

       // if (collision.gameObject.tag == "Interactable")
       // {
       //     Debug.Log("Collision achieved");
       // }

        switch (collision.gameObject.tag) //TODO: Make scene names specific to location on ship
        {
            case "ToScene1":
                Debug.Log("Collision achieved");
                SceneManager.LoadScene(0);
                break;
            case "ToScene2":
                Debug.Log("Collision achieved");
                SceneManager.LoadScene(1);
                break;
            default:
                // Do nothing
                break;

        }
    }
}
