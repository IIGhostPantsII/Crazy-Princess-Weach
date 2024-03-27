using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    public EnemySpawner _enemySpawner;
    public SoundManager _soundManager;
    public Animator _bossAnimator;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enemySpawner.StartCoroutine(_enemySpawner.Delay(Random.Range(1f, 2f)));
            if(gameObject.CompareTag("BossCollider"))
            {
                _soundManager._source.Stop();
                _soundManager.PlayMusic(Globals.CurrentLevel + 8);
            }
            if(_bossAnimator != null)
            {
                _bossAnimator.Play("FinalBoss");
            }
            Destroy(gameObject);
        }
    }
}
