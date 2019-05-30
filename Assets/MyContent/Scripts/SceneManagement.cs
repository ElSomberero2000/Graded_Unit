using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour
{
    Rigidbody rigidBody;

    public Button PlayButton;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        //PlayButton.onClick.AddListener(StartGame);
    }

    private void StartGame() // Loads the first level when the play button is pressed in the main menu
    {
        SceneManager.LoadScene(1);
    }

    private void ExitGame() // Exits the game when the exit button is pressed in the main menu
    {
        Application.Quit();
    }

    // Scene management
    private void OnTriggerEnter(Collider collision)
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
                SceneManager.LoadScene(1); //Loads the first level when the corresponding door is opened in level 2
                break;
            case "ToScene2":
                Debug.Log("Collision achieved");
                SceneManager.LoadScene(2); //Loads the second level when a corresponding door is opened in level 1 or 3
                break;
            case "ToScene3":
                Debug.Log("Collision achieved");
                SceneManager.LoadScene(3); //Loads the three level when a corresponding door is opened in level 2
                break;
            case "Enemy":
                Debug.Log("Collision achieved");
                SceneManager.LoadScene(1); //Loads the first level when the player dies
                break;
            case "ToTitleScreen":
                Debug.Log("Collision achieved");
                SceneManager.LoadScene(0);  //Loads the menu when the final door is opened in level 3
                break;
            default:
                // Do nothing
                break;

        }
    }
}
