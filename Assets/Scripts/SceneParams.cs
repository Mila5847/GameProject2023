using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneParams
{
    public static int points { get; set; }
    public static string gameIdentifier { get; set; }

}

public class LoadSceneWithParameters : MonoBehaviour
{
    public void LoadSceneWithParams(int points, string gameIdentifier)
    {
        SceneParams.points = points;
        SceneParams.gameIdentifier = gameIdentifier;
        SceneManager.LoadScene("Victory");
    }


}
