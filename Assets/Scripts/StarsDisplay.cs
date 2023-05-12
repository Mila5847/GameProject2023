using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    public Transform starContainer1; // The container for the stars
    public Transform starContainer2; // The container for the stars
    public Transform starContainer3; // The container for the stars
    public GameObject starPrefab; // The prefab for the stars

    private int newScore1;
    private int newScore2;
    private int newScore3;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1Status")
        {
            newScore1 = Constants.trapDragonMinigame1Points;
            newScore2 = Constants.cutRopeMinigame1Points;
            newScore3 = Constants.cardsMinigame1Points;
        }
        else if(SceneManager.GetActiveScene().name == "Level2Status")
        {
            newScore1 = Constants.trapDragonMinigame2Points;
            newScore2 = Constants.cutRopeMinigame2Points;
            newScore3 = Constants.cardsMinigame2Points;

        }
        else if(SceneManager.GetActiveScene().name == "Level3Status")
        {
            newScore1 = Constants.trapDragonMinigame3Points;
            newScore2 = Constants.cutRopeMinigame3Points;
            newScore3 = Constants.cardsMinigame3Points;
        }
        else
        {
            newScore1 = Constants.totalPointsLevel1;
            newScore2 = Constants.totalPointsLevel2;
            newScore3 = Constants.totalPointsLevel3;
        }
            // Destroy any previous stars in the container
            foreach (Transform child in starContainer1)
            {
                Destroy(child.gameObject);
            }

            // Instantiate new stars in the container based on the score
            for (int i = 0; i < newScore1; i++)
            {
                GameObject star = Instantiate(starPrefab, starContainer1);
                star.transform.localPosition = new Vector3(i * 100f, 0f, 0f);
            }
     
            // Destroy any previous stars in the container
            foreach (Transform child in starContainer2)
            {
                Destroy(child.gameObject);
            }

            // Instantiate new stars in the container based on the score
            for (int i = 0; i < newScore2; i++)
            {
                GameObject star = Instantiate(starPrefab, starContainer2);
                star.transform.localPosition = new Vector3(i * 100f, 0f, 0f);
            }

            // Destroy any previous stars in the container
            foreach (Transform child in starContainer3)
            {
                Destroy(child.gameObject);
            }

            // Instantiate new stars in the container based on the score
            for (int i = 0; i < newScore3; i++)
            {
                GameObject star = Instantiate(starPrefab, starContainer3);
                star.transform.localPosition = new Vector3(i * 100f, 0f, 0f);
            }
      
    }
}
