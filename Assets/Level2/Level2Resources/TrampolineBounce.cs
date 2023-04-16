using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrampolineBounce : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D rb;

    private bool collided = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
            rb.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, 2 * Time.deltaTime));
            /*// Calculate the direction to the target position
            Vector3 direction = targetPosition.position - objectToMove.position;

            // Move towards the target position using Lerp
            objectToMove.position = Vector3.Lerp(objectToMove.position, targetPosition.position, speed * Time.fixedDeltaTime);*/
        }
    }
}
