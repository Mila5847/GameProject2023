using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("LevelSelector", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {

    }


}
