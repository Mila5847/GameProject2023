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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      
            Debug.Log("IN IT");
            // Get the current score from wherever it's stored
            int newScore1 = Constants.totalPointsLevel1;

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
      
            // Get the current score from wherever it's stored
            int newScore2 = Constants.totalPointsLevel2;

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
     
            // Get the current score from wherever it's stored
            int newScore3 = Constants.totalPointsLevel3;

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
