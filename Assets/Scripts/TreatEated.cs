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

    void Start()
    {
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
            StarsManager.duration = Time.time - StarsManager.startTime;
            if (StarsManager.duration <= 10)
            {
                Debug.Log("TIME " + StarsManager.duration);
                scoreForMinigame = 3;
            }
            if (StarsManager.duration > 10 && StarsManager.duration <= 30)
            {
                Debug.Log("TIME " + StarsManager.duration);
                scoreForMinigame = 2;
            }
            if (StarsManager.duration > 30)
            {
                scoreForMinigame = 1;
                Debug.Log("TIME " + StarsManager.duration);
            }

            string currentScene = SceneManager.GetActiveScene().name;
            Debug.Log("Scene " + currentScene);

            switch (currentScene)
            {
                case "Level1Intro":
                    StarsManager.cutRopeMinigame1Points = scoreForMinigame;
                    Debug.Log("Level 1 and nb points: " + StarsManager.cutRopeMinigame1Points);
                    break;
                case "Level2":
                    StarsManager.cutRopeMinigame2Points = scoreForMinigame;
                    Debug.Log("Level 2 and nb points: " + StarsManager.cutRopeMinigame2Points);
                    break;
                case "Level3":
                    StarsManager.cutRopeMinigame3Points = scoreForMinigame;
                    Debug.Log("Level 3 and nb points " + StarsManager.cutRopeMinigame3Points);
                    StarsManager.startTime = 0;
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
