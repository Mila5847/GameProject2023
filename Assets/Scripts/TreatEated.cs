using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TreatEated : MonoBehaviour
{
    public Sprite closedMouth;
    public Sprite openedMouth;
    private SpriteRenderer spriteRenderer;
    private int scoreForMinigame = 0;

    private LoadSceneWithParameters loader;

    void Start()
    {
        loader = new LoadSceneWithParameters();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedMouth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Meat"))
        {
            spriteRenderer.sprite = openedMouth;
            Destroy(collision.gameObject);
            Invoke("CloseMouth", 0.3f);
            Constants.duration = Time.time - Constants.startTime;
            if (Constants.duration <= 10)
            {
                Debug.Log("TIME " + Constants.duration);
                scoreForMinigame = 3;
            }
            if (Constants.duration > 10 && Constants.duration <= 30)
            {
                Debug.Log("TIME " + Constants.duration);
                scoreForMinigame = 2;
            }
            if (Constants.duration > 30)
            {
                scoreForMinigame = 1;
                Debug.Log("TIME " + Constants.duration);
            }

            string currentScene = SceneManager.GetActiveScene().name;
            Debug.Log("Scene " + currentScene);

            switch (currentScene)
            {
                case "Level1Intro":
                    Constants.cutRopeMinigame1Points = scoreForMinigame;
                    Debug.Log("Level 1 and nb points: " + Constants.cutRopeMinigame1Points);
                    loader.LoadSceneWithParams(scoreForMinigame, "FTD1");
                    break;
                case "Level2Feed":
                    Constants.cutRopeMinigame2Points = scoreForMinigame;
                    Debug.Log("Level 2 and nb points: " + Constants.cutRopeMinigame2Points);
                    loader.LoadSceneWithParams(scoreForMinigame, "FTD2");
                    break;
                case "Level3Feed":
                    Constants.cutRopeMinigame3Points = scoreForMinigame;
                    Debug.Log("Level 3 and nb points " + Constants.cutRopeMinigame3Points);
                    loader.LoadSceneWithParams(scoreForMinigame, "FTD3");
                    //SceneManager.LoadScene("Success");
                    break;
                default:
                    Debug.Log("Unknown scene: " + currentScene);
                    break;
            }

        }
    }
    void CloseMouth()
    {
        spriteRenderer.sprite = closedMouth;
    }
}
