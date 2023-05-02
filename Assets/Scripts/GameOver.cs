using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private string lastScenePlayed = "";

    private void Start()
    {
       lastScenePlayed = PlayerPrefs.GetString("LastScenePlayed");
    }
    public void Replay()
    {
        string lastScenePlayed = PlayerPrefs.GetString("LastScenePlayed"); // Retrieve the last level played
      
        SceneManager.LoadScene(lastScenePlayed); // Load the last level played
    }

    public void ReturnToMenu()
    {
        string gameIdentifier = SceneParams.gameIdentifier;
        Debug.Log("The GAME IDENTIFIER IS: " + gameIdentifier);
        switch (lastScenePlayed)
        {
            case "Level1Intro":
                SceneManager.LoadScene("Level1Status");
                break;
            case "Level2Feed":
                SceneManager.LoadScene("Level2Status");
                break;
            case "Level3Feed":
                SceneManager.LoadScene("Level3Status");
                break;
            default:
                Debug.LogError("Error: Invalid gameIdentifier " + gameIdentifier);
                break;
        }

       /* if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Warning: No scene with the name " + sceneName + " found.");
        }*/
    }
}
