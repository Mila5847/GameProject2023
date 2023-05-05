using UnityEngine;

public class PlayerWalking : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {



    }


}
