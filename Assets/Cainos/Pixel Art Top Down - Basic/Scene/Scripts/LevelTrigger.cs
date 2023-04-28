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
        { "level1", "Level1Status" },
        { "level2", "Level2" },
        { "level3", "Level3" }
    };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("in collison");
        if (gameObject.CompareTag("level1"))
        {
            Debug.Log("level 1");
            SceneManager.LoadScene("Level1Status");
                
        }
        if (gameObject.CompareTag("level2"))
        {
            Debug.Log("level 2");
            //SceneManager.LoadScene("Level1");

        }
        if (gameObject.CompareTag("level3"))
        {
            Debug.Log("level 3");
            //SceneManager.LoadScene("Level1");

        }
    }

}
