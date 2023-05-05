using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    // Reference to the meat object
    private GameObject meat;

    // Flag to check if the meat is stuck to the paddle
    private bool meatStuck = false;

    void Start()
    {
        // Find the meat object using its tag
        meat = GameObject.FindGameObjectWithTag("Meat");
    }

    void Update()
    {
     
        if(meat != null)
        {
            // If the meat is stuck to the paddle, move it along with the paddle
            if (meatStuck)
            {
                meat.transform.position = transform.position + new Vector3(0, 0.50f, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("In collision");
        if (collision.gameObject.CompareTag("Meat") && !meatStuck)
        {

            // Make the meat a child of the paddle at the correct relative position
            collision.transform.SetParent(transform);

            // Set the meatStuck flag to true
            meatStuck = true;
        }
    }
}
