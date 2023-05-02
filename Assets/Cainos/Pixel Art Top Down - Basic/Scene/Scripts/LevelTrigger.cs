using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("in trigger");
        if (gameObject.CompareTag("level1"))
        {
            Debug.Log("level 1");
            PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetFloat("playerPositionX", transform.position.x);
            PlayerPrefs.SetFloat("playerPositionY", transform.position.y);
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("Level1Status");
            }
            //

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
