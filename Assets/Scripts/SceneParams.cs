using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneParams
{
    public static int points { get; set; }

}

public class LoadSceneWithParameters : MonoBehaviour
{
    public void LoadSceneWithParams(int points)
    {
        SceneParams.points = points;
        SceneManager.LoadScene("Victory");
    }


}
