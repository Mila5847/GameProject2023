using UnityEngine;
using UnityEngine.UI;

public class ExitBtnScript : MonoBehaviour
{

    public GameObject exitObject;
    private Button exitBtn;
    // Start is called before the first frame update
    void Start()
    {
        exitBtn = exitObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            exitBtn.onClick.Invoke();
        }
    }

    public void OnApplicationQuit()
    {

        Application.Quit();


    }
}
