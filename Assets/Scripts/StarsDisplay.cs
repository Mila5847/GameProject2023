using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{

    public Text scoreText1;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current score from wherever it's stored
        int newScore = Constants.totalPointsLevel1;

       // Update the score text
       scoreText1.text = newScore.ToString();
        Debug.Log(Constants.totalPointsLevel1);
    }   
}
