using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Replay()
    {
        string lastScenePlayed = PlayerPrefs.GetString("LastScenePlayed"); // Retrieve the last level played
        SceneManager.LoadScene(lastScenePlayed); // Load the last level played
    }

    public void MainScene()
    {
        SceneManager.LoadScene("MainSceneLevels");
    }
}
