using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : SceneManager
{
    public static void LoadScene(string sceneName, LoadSceneMode mode, SceneParameters sceneParams)
    {
        // Load the scene using the base SceneManager.LoadScene() method
        SceneManager.LoadScene(sceneName, mode);

        // Attach the scene parameters to the newly loaded scene
        Scene loadedScene = SceneManager.GetSceneByName(sceneName);
        if (loadedScene.IsValid())
        {
            loadedScene.SetSceneParameters(sceneParams);
        }
    }
    
}
