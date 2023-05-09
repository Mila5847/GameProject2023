using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class LevelTrigger : MonoBehaviour
{
    private void Start()
    {
        
    }



    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) {
            collision.gameObject.GetComponent<Rigidbody2D>().WakeUp();
        //Debug.Log("in trigger");
        if (Input.GetKeyDown(KeyCode.Return)) { 
        //Debug.Log("keydown");

        if (gameObject.CompareTag("level1"))
        {
            Debug.Log("level 1");
            PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().name);
            PlayerPrefs.SetFloat("playerPositionX", transform.position.x);
            PlayerPrefs.SetFloat("playerPositionY", transform.position.y);
            SceneManager.LoadScene("Level1Status");
           
        }
        else if (gameObject.CompareTag("level2"))
        {
                    //Debug.Log("level 2");
           if (Constants.isLevel2Unlocked == true)
              {
               SceneManager.LoadScene("Level2Status");
              }
           else
              {
               SceneManager.LoadScene("LevelLocked");
              }
        }
        else if (gameObject.CompareTag("level3"))
        {
                    //Debug.Log("level 2");
            if (Constants.isLevel3Unlocked == true)
            {
               SceneManager.LoadScene("Level3Status");
            }
            else
            {
               SceneManager.LoadScene("LevelLocked");
            }
        }
    }
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
