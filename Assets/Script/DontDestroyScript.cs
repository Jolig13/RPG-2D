using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{   
    private void Awake()
    {
    
        var DestroyCancelled = FindObjectsOfType<DontDestroyScript>();

        if (DestroyCancelled.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
