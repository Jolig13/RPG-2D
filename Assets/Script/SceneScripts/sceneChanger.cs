using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{   
    [SerializeField] private string sceneName;
    [SerializeField] private Vector2 playerPosition;
    [SerializeField] private VectorValueScript playerStoragePos;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            playerStoragePos.initialValue = playerPosition;
            SceneManager.LoadScene(sceneName);
        }   
    }
}
