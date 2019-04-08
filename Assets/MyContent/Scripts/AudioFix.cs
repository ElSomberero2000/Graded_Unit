using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFix : MonoBehaviour
{
    static AudioFix instance = null;

    private void Awake()
    {
        // Allows ongoing audio to continue after loading a new scene
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
