using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update

    public void LoadScene(string sceneName)
    {
        if(sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Warning: No scene with the name " + sceneName + " found.");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
