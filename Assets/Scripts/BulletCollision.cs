using System.Collections;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            return;
        }
        else if(collision.CompareTag("Boss"))
        {
            BossCharacter<int>.SubtractHealth(10);
            if(true)
            {
                GameObject kapow = collision.gameObject.transform.parent.gameObject;
                Animator kapowAnimator = kapow.GetComponent<Animator>();
                kapowAnimator.Play("Kapow");
                _soundManager._source.PlayOneShot(_soundManager._clips[1]);

                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
        
        Destroy(gameObject);
    }
}
