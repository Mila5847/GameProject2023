using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CardGame1_TurnCard : MonoBehaviour
{

    private int seconds = 2;
    // Start is called before the first frame update
    void Start()
    {


    }
    IEnumerator SecondsCoroutine()
    {
        Debug.Log("Waits 2 seconds before turning");
        yield return seconds;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown((int)MouseButton.Left) && gameObject.CompareTag("Card1"))
        {

            //hide
            gameObject.GetComponent<Renderer>().enabled = false;

        }
        if (Input.GetMouseButtonDown((int)MouseButton.Left) && gameObject.CompareTag("Card2"))
        {

            //hide
            gameObject.GetComponent<Renderer>().enabled = false;

        }
        if (Input.GetMouseButtonDown((int)MouseButton.Left) && gameObject.CompareTag("Card3"))
        {

            //hide
            gameObject.GetComponent<Renderer>().enabled = false;

        }
        else if (Input.GetMouseButtonDown((int)MouseButton.Left) && (gameObject.CompareTag("Card1") != gameObject.CompareTag("Card1")) || (gameObject.CompareTag("Card2") != gameObject.CompareTag("Card2")) || (gameObject.CompareTag("Card3") != gameObject.CompareTag("Card3")))
        {
            StartCoroutine(SecondsCoroutine());
            gameObject.GetComponent<Renderer>().enabled = true;

        }


    }
}
