using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseMenu;

    public Canvas optionsMenu;

    /*[SerializeField]
    private Canvas interrogationMenu;*/

    [SerializeField]
    private Slider volumeSlider;

    public Toggle mute;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
        optionsMenu.enabled = false;
       // interrogationMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.enabled = false;
            optionsMenu.enabled = !optionsMenu.enabled;
            if (!optionsMenu.enabled)
            {
                Time.timeScale = 1;
            }
            //interrogationMenu.enabled = false;
        }
    }
    
    public void ChangeVolume()
    {
        if (mute.isOn)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = volumeSlider.value;
        }
    }

    public void ShowPauseMenu()
    {
       
            Time.timeScale = 0;
            pauseMenu.enabled = true;
            optionsMenu.enabled = false;
            //interrogationMenu.enabled = false;
        

    }

    public void HidePauseMenu()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Time.timeScale = 1;
            pauseMenu.enabled = false;
            optionsMenu.enabled = false;
            //interrogationMenu.enabled = false;
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainSceneLevels");
    }
}
