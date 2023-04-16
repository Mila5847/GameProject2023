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
    private string lastLevelName;

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
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "Level1Intro")
            {
                // Save the current level name
                lastLevelName = "Level1Intro";
            }
            else if (currentScene == "Level2")
            {
                lastLevelName = "Level2";
            }
            else if (currentScene == "Level3")
            {
                lastLevelName = "Level3";
            }
            PlayerPrefs.SetString("LastScenePlayed", lastLevelName); // Save the last level played
            SceneManager.LoadScene("GameOver");
        }
        else if (pos.y >= top)
        {
            pos.y = top; // Set the position to the top limit
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "Level1")
            {
                // Save the current level name
                lastLevelName = "Level1";
            }
            else if (currentScene == "Level2")
            {
                lastLevelName = "Level2";
            }
            else if (currentScene == "Level3")
            {
                lastLevelName = "Level3";
            }
            PlayerPrefs.SetString("LastScenePlayed", lastLevelName); // Save the last level played
            SceneManager.LoadScene("GameOver");
        }

        // Update the position of the game object
        transform.position = pos;
    }
}
