using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrampolineBounce : MonoBehaviour
{
    // Reference to the ball object
    private GameObject ball;

    // Flag to check if the ball is stuck to the paddle
    private bool ballStuck = false;

    // Speed at which the paddle moves
    public float speed = 5f;

    // Release force for the ball when it is released
    public float releaseForce = 10f;

    void Start()
    {
        // Find the ball object using its tag
        ball = GameObject.FindGameObjectWithTag("Meat");
    }

    void Update()
    {
        // Move the paddle horizontally
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        // If the ball is stuck to the paddle, move it along with the paddle
        if (ballStuck)
        {
            ball.transform.position = transform.position + new Vector3(0, 0.75f, 0);

            // If the player presses the space key, release the ball
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ballStuck = false;
                ball.GetComponent<Rigidbody2D>().isKinematic = false;
                ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, releaseForce), ForceMode2D.Impulse);
                ball.transform.parent = null;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("In Collision");
        if (other.gameObject.CompareTag("TrampolineDown"))
        {
            Debug.Log("In Collision with trampoline");
            // Make the ball a child of the paddle
            other.gameObject.transform.parent = transform;

            // Disable the ball's rigidbody
            other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            // Set the ballStuck flag to true
            ballStuck = true;
        }
    }
}
