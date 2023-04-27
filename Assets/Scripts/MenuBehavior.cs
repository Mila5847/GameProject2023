using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuBehavior : MonoBehaviour
{
    [SerializeField]
    private Canvas pauseMenu;

    public Canvas optionsMenu;

    [SerializeField]
    private Canvas interrogationMenu;

    [SerializeField]
    private Slider volumeSlider;

    public Toggle mute;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
        optionsMenu.enabled = false;
        interrogationMenu.enabled = false;
    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.enabled = true;
            optionsMenu.enabled = false;
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
    }*/

    public void ShowPauseMenu()
    {
        pauseMenu.enabled = true;
        optionsMenu.enabled = false;
        interrogationMenu.enabled = false;
    }

    public void HidePauseMenu()
    {
        pauseMenu.enabled = false;
        optionsMenu.enabled = false;
        interrogationMenu.enabled = false;
    }

    public void QuitGame()
    {
        pauseMenu.enabled = false;
        optionsMenu.enabled = false;
        interrogationMenu.enabled = false;
        SceneManager.LoadScene("MainSceneLevels");
    }


    /*public void GoToMainMenu()
    {
        pauseMenu.enabled = true;
        optionsMenu.enabled = false;
    }

    public void MainMenuResume()
    {
        pauseMenu.enabled = false;
        optionsMenu.enabled = false;
    }

    public void MainMenuQuit()
    {
        Application.Quit();
    }*/
}
