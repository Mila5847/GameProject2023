using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public float distanceFromChainEnd = 0.6f;
    public void ConnectRopeEnd(Rigidbody2D endRigidbody2D)
    {
        HingeJoint2D joint =  gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        // Set connected body to wait of link chain
        joint.connectedBody = endRigidbody2D;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f, -distanceFromChainEnd);
    }
}
