using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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


        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {

            Vector3 cardRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D clickedCard = Physics2D.Raycast(cardRay, Vector2.zero);


            if ((clickedCard.Equals(cards[0]) && (clickedCard.Equals(cards[1]))) || (clickedCard.Equals(cards[2]) && (clickedCard.Equals(cards[3]))) || (clickedCard.Equals(cards[4]) && (clickedCard.Equals(cards[5]))))
            {
                Debug.Log(clickedCard.collider.name + "was clicked");
                //hide 
                gameObject.GetComponent<Renderer>().enabled = false;


            }
            else if (clickedCard)
            {

                //show non-flipped card
                gameObject.GetComponent<Renderer>().enabled = true;
                StartCoroutine(SecondsCoroutine());

            }



        }



    }
}
