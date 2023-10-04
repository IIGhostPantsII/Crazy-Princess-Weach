using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public string _sceneName;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Warping...");
            SceneManager.LoadScene(_sceneName);
        }
    }
}
