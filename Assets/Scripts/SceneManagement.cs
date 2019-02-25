using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Scene management
    void SceneChangeOnCollision(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ToScene1":
                SceneManager.LoadScene(0);
                break;
            case "ToScene2":
                SceneManager.LoadScene(1);
                break;
            default:
                // Do nothing
                break;
        }
    }
}
