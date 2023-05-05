using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Leaf"))
        {
            // Find all the Rope scripts in the scene and destroy them
            Rope[] ropeScripts = FindObjectsOfType<Rope>();
            foreach (Rope ropeScript in ropeScripts)
            {
                Destroy(ropeScript.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
