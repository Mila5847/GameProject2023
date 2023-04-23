using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsManager : MonoBehaviour
{
    public static float startTime = 0; 
    public static float duration = 0;

    public static int trapDragonMinigame1Points = 0;
    public static int trapDragonMinigame2Points = 0;
    public static int trapDragonMinigame3Points = 0;

    public static int cutRopeMinigame1Points = 0;
    public static int cutRopeMinigame2Points = 0;
    public static int cutRopeMinigame3Points = 0;

    public static int cardsMinigame1Points = 0;
    public static int cardsMinigame2Points = 0;
    public static int cardsMinigame3Points = 0;

    // Update is called once per frame
    void Update()
    {
        // Check if the player has earned at least one star in each minigame on level 1
        if (trapDragonMinigame1Points >= 1 && trapDragonMinigame2Points >= 1 && trapDragonMinigame3Points >= 1)
        {
            // Unlock level 2 by loading the next scene
            //SceneManager.LoadScene("Level2");
        }
        if(cutRopeMinigame1Points >= 2 && cutRopeMinigame2Points >= 2 && cutRopeMinigame3Points >= 2)
        {
            // unlock scene
            Debug.Log("ALL LEVEL SUCCESS");
        }
    }
}
