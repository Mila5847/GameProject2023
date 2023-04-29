using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public int links = 7;
    public Weight weight;
    // Start is called before the first frame update
    void Start()
    {
        CreateRope();
    }

    void CreateRope()
    {
        // First link in chain should be connected to the hook
        Rigidbody2D previousRigidBody = hook;
        for(int i = 0; i < links; i++)
        {
            // Create reference of the HingeJoint2D on the link 
            // Create reference to the linkPrefab that has been spawned
            GameObject link = Instantiate(linkPrefab, transform);

            // Get the HingeJoint component of the link
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();

            // Connection of rigidbody with the previous link
            joint.connectedBody = previousRigidBody;

            if(i < links - 1)
            {
                // Update previous rigidbody 
                previousRigidBody = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                weight.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
            
        }
    }
}
