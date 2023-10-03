using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] _enemies;
    int[] _lastRand;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Delay(1f));
    }

    private IEnumerator Delay(float seconds)
    {
        _lastRand = new int[_enemies.Length];
        for(int i = 0; i < _enemies.Length; i++)
        {
            yield return new WaitForSeconds(seconds);
            int random = Random.Range(0, _enemies.Length);
            if(i != 0)
            {
                for (int j = 1; j <= i; j++)
                {
                    while (random == _lastRand[j - 1])
                    {
                        random = Random.Range(0, _enemies.Length);
                    }
                }
            }
            _lastRand[i] = random;
            Debug.Log($"Turning on {random}.");
            _enemies[random].SetActive(true);
        }
    }
}
