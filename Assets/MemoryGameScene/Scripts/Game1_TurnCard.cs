using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardGame1_TurnCard : MonoBehaviour
{
    public List<GameObject> cards;
    // private int seconds = 2;

    // Start is called before the first frame update
    void Start()
    {


    }
    IEnumerator SecondsCoroutine()
    {
        Debug.Log("Waits 2 seconds before turning");

        yield return new WaitForSeconds(2.0f);


    }

    // Update is called once per frame
    void Update()
    {






    }
}
