using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject _dead;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            Time.timeScale = true ? 0 : 1;
            Cursor.visible = true;
            Cursor.lockState = true ? CursorLockMode.None : CursorLockMode.Locked;
            _dead.SetActive(true);
            Globals.Death();
        }
    }
}
