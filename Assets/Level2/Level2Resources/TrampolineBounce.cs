using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineBounce : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public Transform topRectangle;
    public Transform bottomRectangle;
    public GameObject trampolineUp;

    private bool isBouncing = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TrampolineDown"))
        {
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    private void Update()
    {
        if(rigidbody.bodyType == RigidbodyType2D.Kinematic)
        {
            transform.Translate(transform.up * 20f * Time.deltaTime);
        }
        if (isBouncing && rigidbody.transform.position.y >= trampolineUp.transform.position.y)
        {
            Debug.Log("Gelo");
            isBouncing = false;
        }
    }
}
