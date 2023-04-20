using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TrampolineBounce : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.gameObject.CompareTag("TrampolineDown"))
         {
             Rigidbody2D rb = GetComponent<Rigidbody2D>();
             rb.constraints = RigidbodyConstraints2D.FreezeAll;
             rb.transform.SetParent(collision.gameObject.transform);
         }
     }
}
