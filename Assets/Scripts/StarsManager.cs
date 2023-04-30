using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarsManager : MonoBehaviour
{

    // Update is called once per frame

    public Text pointsCounter1Text;
    public Text pointsCounter2Text;
    public Text pointsCounter3Text;

    void Update()
    {
        if (SceneParams.gameIdentifier == "TTD1")
        {
            Debug.Log("First game trap: " + Constants.trapDragonMinigame1Points);
            Debug.Log("First game feed: " + Constants.cutRopeMinigame1Points);
            pointsCounter1Text.text = Constants.trapDragonMinigame1Points.ToString();
            pointsCounter2Text.text = Constants.cutRopeMinigame1Points.ToString();
            pointsCounter3Text.text = Constants.cardsMinigame1Points.ToString();

        }

        if (SceneParams.gameIdentifier == "FTD1")
        {
            Debug.Log("Second game trap " + Constants.trapDragonMinigame1Points);
            Debug.Log("Second game eat " + Constants.cutRopeMinigame1Points);
            pointsCounter1Text.text = Constants.trapDragonMinigame1Points.ToString();
            pointsCounter2Text.text = Constants.cutRopeMinigame1Points.ToString();
            pointsCounter3Text.text = Constants.cardsMinigame1Points.ToString();

        }

        if(SceneParams.gameIdentifier == "MC1")
        {
            Debug.Log("Second game trap " + Constants.trapDragonMinigame1Points);
            Debug.Log("Second game eat " + Constants.cutRopeMinigame1Points);
            Debug.Log("Third game eat " + Constants.cardsMinigame1Points);
            pointsCounter1Text.text = Constants.trapDragonMinigame1Points.ToString();
            pointsCounter2Text.text = Constants.cutRopeMinigame1Points.ToString();
            pointsCounter3Text.text = Constants.cardsMinigame1Points.ToString();
        }

        if (SceneParams.gameIdentifier == "TTD2")
        {
            Debug.Log("Second game trap " + Constants.trapDragonMinigame2Points);
            Debug.Log("Second game eat " + Constants.cutRopeMinigame2Points);
            Debug.Log("Third game eat " + Constants.cardsMinigame2Points);
            pointsCounter1Text.text = Constants.trapDragonMinigame2Points.ToString();
            pointsCounter2Text.text = Constants.cutRopeMinigame2Points.ToString();
            pointsCounter3Text.text = Constants.cardsMinigame2Points.ToString();
        }

        if (SceneParams.gameIdentifier == "FTD2")
        {
            Debug.Log("Second game trap " + Constants.trapDragonMinigame2Points);
            Debug.Log("Second game eat " + Constants.cutRopeMinigame2Points);
            Debug.Log("Third game eat " + Constants.cardsMinigame2Points);
            pointsCounter1Text.text = Constants.trapDragonMinigame2Points.ToString();
            pointsCounter2Text.text = Constants.cutRopeMinigame2Points.ToString();
            pointsCounter3Text.text = Constants.cardsMinigame2Points.ToString();
        }

        // Check if the player has earned at least one star in each minigame on level 1
        if (Constants.trapDragonMinigame1Points >= 1 && Constants.trapDragonMinigame2Points >= 1 && Constants.trapDragonMinigame3Points >= 1)
        {
            // Unlock level 2 by loading the next scene
            //SceneManager.LoadScene("Level2");
        }
        if(Constants.cutRopeMinigame1Points >= 2 && Constants.cutRopeMinigame2Points >= 2 && Constants.cutRopeMinigame3Points >= 2)
        {
            // unlock scene
            Debug.Log("ALL LEVEL SUCCESS");
        }
    }
}
