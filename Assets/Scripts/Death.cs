using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject _dead;

    private void OnTriggerEnter(Collider collision)
    {
        // Check if the collision is with an object tagged as "Boss" and the player's tag is "Player."
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Dead");
            Time.timeScale = true ? 0 : 1;
            Cursor.visible = true;
            Cursor.lockState = true ? CursorLockMode.None : CursorLockMode.Locked;
            _dead.SetActive(true);
            Globals.Death();
            Debug.Log(Globals.DeathScreen);
        }
    }
}
