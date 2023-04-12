using UnityEngine;
using UnityEngine.UI;

public class ExitBtnScript : MonoBehaviour
{
    [SerializeField]
    private Button exitBtn;
    public void quit()
    {

        Application.Quit();



    }
}
