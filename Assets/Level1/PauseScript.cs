using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField]
    bool IsPaused = false;

    [SerializeField]
    GameObject PauseCanvas;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                ResumeMe();
            }
            else
            {
                PauseMe();
            }

        }

    }

    public void PauseMe()
    {

        Time.timeScale = 0;
        IsPaused = true;
        PauseCanvas.SetActive(true);


    }

    public void ResumeMe()
    {

        Time.timeScale = 1;
        IsPaused = false;
        PauseCanvas.SetActive(false);

    }
}
