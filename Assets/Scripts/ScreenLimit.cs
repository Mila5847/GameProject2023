using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLimit : MonoBehaviour
{
    public int top;
    public int bottom;
    public int left;
    public int right;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the current position of the game object
        Vector2 pos = transform.position;

        // Check if the game object is outside the left or right screen limits
        if (pos.x <= left)
        {
            pos.x = left; // Set the position to the left limit
        }
        else if (pos.x >= right)
        {
            pos.x = right; // Set the position to the right limit
        }

        // Check if the game object is outside the top or bottom screen limits
        if (pos.y <= bottom)
        {
            pos.y = bottom; // Set the position to the bottom limit
            SceneManager.LoadScene("GameOver");
        }
        else if (pos.y >= top)
        {
            pos.y = top; // Set the position to the top limit
        }

        // Update the position of the game object
        transform.position = pos;
    }
}
