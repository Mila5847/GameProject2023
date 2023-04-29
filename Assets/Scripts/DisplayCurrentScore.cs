using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCurrentScore : MonoBehaviour
{
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Current score display " + Constants.currentScore);
        score.text = Constants.currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
