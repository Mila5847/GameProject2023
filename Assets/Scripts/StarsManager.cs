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

    private void Start()
    {
        int lvl1 = Constants.cutRopeMinigame1Points + Constants.cardsMinigame1Points + Constants.trapDragonMinigame1Points;
        if (lvl1 >= 3) 
            Constants.isLevel2Unlocked = true;

        int lvl2 = Constants.cutRopeMinigame2Points + Constants.cardsMinigame2Points + Constants.trapDragonMinigame2Points;


        if (lvl2 >= 6)
            Constants.isLevel3Unlocked = true;


        //        int lvl3 = Constants.cutRopeMinigame3Points + Constants.cardsMinigame3Points + Constants.trapDragonMinigame3Points;
    }

    void Update()
    {
        Debug.Log("Star manager : " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name.Equals("Level3Status") && Constants.isLevel3Unlocked)
        {
            pointsCounter1Text.text = Constants.trapDragonMinigame3Points.ToString();
            pointsCounter2Text.text = Constants.cutRopeMinigame3Points.ToString();
            pointsCounter3Text.text = Constants.cardsMinigame3Points.ToString();
            Constants.totalPointsLevel3 = Constants.trapDragonMinigame3Points + Constants.cutRopeMinigame3Points + Constants.cardsMinigame3Points;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level2Status") && Constants.isLevel2Unlocked)
        {
            pointsCounter1Text.text = Constants.trapDragonMinigame2Points.ToString();
            pointsCounter2Text.text = Constants.cutRopeMinigame2Points.ToString();
            pointsCounter3Text.text = Constants.cardsMinigame2Points.ToString();
            Constants.totalPointsLevel2 = Constants.trapDragonMinigame2Points + Constants.cutRopeMinigame2Points + Constants.cardsMinigame2Points;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Level1Status"))
        {
            pointsCounter1Text.text = Constants.trapDragonMinigame1Points.ToString();
            pointsCounter2Text.text = Constants.cutRopeMinigame1Points.ToString();
            pointsCounter3Text.text = Constants.cardsMinigame1Points.ToString();
            Constants.totalPointsLevel1 = Constants.trapDragonMinigame1Points + Constants.cutRopeMinigame1Points + Constants.cardsMinigame1Points;
        }
    }
}