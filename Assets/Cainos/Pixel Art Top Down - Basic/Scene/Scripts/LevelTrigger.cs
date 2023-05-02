using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
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
            PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetFloat("playerPositionX", transform.position.x);
            PlayerPrefs.SetFloat("playerPositionY", transform.position.y);
            //SceneManager.LoadScene("Level1Status");

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

    public void BackToGame()
    {
        string previousScene = PlayerPrefs.GetString("previousScene");
        SceneManager.LoadScene(previousScene);
        float playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
        float playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector2(playerPositionX, playerPositionY);
    }
}
