using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    public EnemySpawner _enemySpawner;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Yo!");
            _enemySpawner.StartCoroutine(_enemySpawner.Delay(Random.Range(1f, 2f)));
            Destroy(gameObject);
        }
    }
}
