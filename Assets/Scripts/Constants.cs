using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Constants
{
    public static float startTime = 0;
    public static float duration = 0;

    public static bool isLevel2Unlocked = false;
    public static bool isLevel3Unlocked = false;

    public static int trapDragonMinigame1Points = 0;
    public static int trapDragonMinigame2Points = 0;
    public static int trapDragonMinigame3Points = 0;

    public static int cutRopeMinigame1Points = 0;
    public static int cutRopeMinigame2Points = 0;
    public static int cutRopeMinigame3Points = 0;

    public static int cardsMinigame1Points = 0;
    public static int cardsMinigame2Points = 0;
    public static int cardsMinigame3Points = 0;

    public static int totalPointsLevel1 = 0;
    public static int totalPointsLevel2 = 0;
    public static int totalPointsLevel3 = 0;

    public static int currentScore = 0;

    public static Text pointsCounter1;
    public static Text pointsCounter2;
    //public Text pointsCounter3;


    public static List<PathObject> waypointGameObjects = new List<PathObject>();
}
