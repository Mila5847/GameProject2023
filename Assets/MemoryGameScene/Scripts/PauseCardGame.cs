using UnityEngine;

public class PauseCardGame : MonoBehaviour
{
    [SerializeField]
    bool isPaused = false;

    [SerializeField]
    GameObject PauseCanvas;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
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
        isPaused = true;
        PauseCanvas.SetActive(true);
    }

    public void ResumeMe()
    {
        Time.timeScale = 1;
        isPaused = false;
        PauseCanvas.SetActive(false);

    }
}

