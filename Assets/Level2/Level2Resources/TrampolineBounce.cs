using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrampolineBounce : MonoBehaviour
{
    public Transform objectToMove;
    public Transform targetPosition;
    public float speed = 1f;

    private bool collided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TrampolineDown"))
        {
            collided = true;
        }
    }

    private void FixedUpdate()
    {
        if (collided)
        {
            // Calculate the direction to the target position
            Vector3 direction = targetPosition.position - objectToMove.position;

            // Move towards the target position using Lerp
            objectToMove.position = Vector3.Lerp(objectToMove.position, targetPosition.position, speed * Time.fixedDeltaTime);
        }
    }
}
