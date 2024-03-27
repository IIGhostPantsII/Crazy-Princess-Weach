using System.Collections;
using UnityEngine;

public class MovePositions : MonoBehaviour
{
    public Transform[] movePoints;
    public float maxMoveDelay = 3.0f;

    private int currentIndex = 0;
    private Transform targetPoint;
    private bool isMoving = false;

    private void Start()
    {
        if (movePoints.Length == 0)
        {
            Debug.LogError("Please assign move points in the inspector.");
            enabled = false;
        }

        targetPoint = movePoints[currentIndex];
        StartCoroutine(MoveToTarget());
    }

    private IEnumerator MoveToTarget()
    {
        while (true)
        {
            if (!isMoving)
            {
                float moveDuration = 1.0f;
                float moveStartTime = Time.time;
                Vector3 startPosition = transform.position;
                Vector3 endPosition = targetPoint.position;

                while (Time.time - moveStartTime < moveDuration)
                {
                    float t = (Time.time - moveStartTime) / moveDuration;
                    transform.position = Vector3.Lerp(startPosition, endPosition, t);
                    yield return null;
                }

                transform.position = endPosition;
                isMoving = true;

                float moveDelay = Random.Range(0.0f, maxMoveDelay);
                yield return new WaitForSeconds(moveDelay);

                currentIndex = (currentIndex + 1) % movePoints.Length;
                targetPoint = movePoints[currentIndex];
                isMoving = false;
            }
            else
            {
                yield return null;
            }
        }
    }
}
