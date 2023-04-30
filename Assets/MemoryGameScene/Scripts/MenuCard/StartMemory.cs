using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMemory : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log("Loaded");
        SceneManager.LoadScene(sceneName);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
