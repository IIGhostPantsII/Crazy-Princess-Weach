using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DieNOW());
    }

    private IEnumerator DieNOW()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
