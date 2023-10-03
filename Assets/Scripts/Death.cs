using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the collision is with an object tagged as "Boss" and the player's tag is "Player."
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Dead");
        }
    }
}
