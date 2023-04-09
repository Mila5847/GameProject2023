using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public Transform topRectangle;
    public Transform bottomRectangle;

    private bool isStickingToBottom = false;
    private bool isStickingToTop = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TrampolineDown"))
        {
            // Stick the ball to the bottom rectangle
            ballRigidbody.bodyType = RigidbodyType2D.Dynamic;
            ballRigidbody.velocity = Vector2.zero;
            ballRigidbody.transform.SetParent(bottomRectangle, true);
            isStickingToBottom = true;
        }
        else if (collision.gameObject.CompareTag("Trampoline"))
        {
            // Stick the ball to the top rectangle
            ballRigidbody.bodyType = RigidbodyType2D.Dynamic;
            ballRigidbody.velocity = Vector2.zero;
            ballRigidbody.transform.SetParent(topRectangle, true);
            isStickingToTop = true;
        }
    }

    private void Update()
    {
        if (isStickingToBottom && Input.GetKeyDown(KeyCode.K))
        {
            // Bounce off the bottom rectangle
            ballRigidbody.transform.SetParent(null, true);
            ballRigidbody.bodyType = RigidbodyType2D.Dynamic;
            ballRigidbody.velocity = (Vector2.up * 10f);
            isStickingToBottom = false;
        }
        else if (isStickingToTop && Input.GetKeyDown(KeyCode.D))
        {
            // Release the ball from the top rectangle
            ballRigidbody.transform.SetParent(null, true);
            ballRigidbody.bodyType = RigidbodyType2D.Dynamic;
            isStickingToTop = false;
        }
    }
}
