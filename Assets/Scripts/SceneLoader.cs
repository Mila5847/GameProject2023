using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        string gameIdentifier = SceneParams.gameIdentifier;
        GameObject backButton = GameObject.FindWithTag("BackToMenu");
        switch (gameIdentifier)
        {
            case "TTD1":
            case "FTD1":
            case "MC1":
                backButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => LoadScene("Level1Status"));
                break;
            case "TTD2":
            case "FTD2":
            case "MC2":
                backButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => LoadScene("Level2Status"));
                break;
            case "TTD3":
            case "FTD3":
            case "MC3":
                backButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => LoadScene("Level3Status"));
                break;
            default:
                Debug.LogError("Error: Invalid gameIdentifier " + gameIdentifier);
                break;
        }
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        Debug.Log("Load scene pleaaase");
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Warning: No scene with the name " + sceneName + " found.");
        }
    }

    public void AfterGameOverScene()
    {
        string gameIdentifier = SceneParams.gameIdentifier;
        Debug.Log("THE GAME ID IS : " + gameIdentifier);
        switch (gameIdentifier)
        {
            case "TTD1":
            case "FTD1":
            case "MC1":
                LoadScene("Level1Intro");
                break;
            case "TTD2":
            case "FTD2":
            case "MC2":
                LoadScene("Level2Feed");
                break;
            case "TTD3":
            case "FTD3":
            case "MC3":
                LoadScene("Level3Feed");
                break;
            default:
                Debug.LogError("Error: Invalid gameIdentifier " + gameIdentifier);
                break;
        }
    }

    public void Replay()
    {
        string lastScenePlayed = PlayerPrefs.GetString("LastScenePlayed"); // Retrieve the last level played
        Debug.Log("Scene name is: " + lastScenePlayed);
        SceneManager.LoadScene(lastScenePlayed); // Load the last level played
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
