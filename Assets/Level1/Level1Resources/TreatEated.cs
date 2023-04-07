using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreatEated : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object is Object A
        if (other.gameObject.CompareTag("Player"))
        {
            // Destroy Object A
            Destroy(other.gameObject);
        }
    }
}
