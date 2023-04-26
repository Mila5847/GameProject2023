using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeSpent = 00.0f;
    public Text timerText;

    void Update()
    {
        timeSpent += Time.deltaTime;
        timerText.text = "Time (seconds): " + Mathf.Round(timeSpent).ToString();

        if (timeSpent == 60)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
