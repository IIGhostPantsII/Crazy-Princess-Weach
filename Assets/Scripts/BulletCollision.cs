using System.Collections;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private GameObject[] _portal;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            return;
        }
        else if(collision.CompareTag("Spawn"))
        {
            return;
        }

        if(collision.CompareTag("Boss") && gameObject.CompareTag("BossBullet"))
        {
            return;
        }
        else if(collision.CompareTag("Boss"))
        {
            BossCharacter<int>.SubtractHealth(10);
            if (Globals.EnemyDeath)
            {
                GameObject kapow = collision.gameObject.transform.parent.gameObject;
                Animator kapowAnimator = kapow.GetComponent<Animator>();
                kapowAnimator.Play("Kapow");
                _soundManager._source.PlayOneShot(_soundManager._clips[1]);
                BossSetup.ResetEnemy();
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Wowzer"))
        {
            BossCharacter<int>.SubtractHealth(10);
            if(Globals.EnemyDeath)
            {
                _portal[Globals.CurrentLevel].SetActive(true);
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
