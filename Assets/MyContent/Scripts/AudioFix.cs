using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFix : MonoBehaviour
{
    static AudioFix instance = null;

    private void Awake()
    {
        // Allows audio to continue after loading a new scene
        // Applied to the background music so there is not skipping/repeating of the track
        DontDestroyOnLoad(transform.gameObject);

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
