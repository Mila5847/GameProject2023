using UnityEngine;

public class CardInteractionsLimit : MonoBehaviour
{
    public int count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            count++;
        }
    }



    /*
    else
    {

        if (Input.GetMouseButton(0))
        {
            enabled = false;
        }


    }
    */



}
