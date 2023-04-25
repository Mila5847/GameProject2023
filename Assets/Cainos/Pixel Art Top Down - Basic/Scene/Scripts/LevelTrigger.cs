using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Dictionary<string, string> levelSceneMap = new Dictionary<string, string>()
    {
        { "level1", "Level1" },
        { "level2", "Level2" },
        { "level3", "Level3" }
    };

    void OnTriggerEnter(Collider other)
    {
        string sceneName;
        if (levelSceneMap.TryGetValue(other.tag, out sceneName))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("triggered");
        }
    }
}
