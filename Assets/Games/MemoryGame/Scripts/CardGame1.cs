using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class CardGame1 : MonoBehaviour
{

    public List<GameObject> cards;
    [SerializeField]
    List<GameObject> cardSprites;
    private bool show = false;
    private bool isInvoked = false;

    [SerializeField]
    Text cardTextCounter;

    [SerializeField]
    private int timeForLevel = 30;

    private int seconds = 1;

    private bool firstCard = false;
    private int missedMatches = 0;
    private int pointCount = 0;

    private Stack<int> cardValues = new Stack<int>();
    private Stack<GameObject> selectedCards = new Stack<GameObject>();

    public RaycastHit2D clicked;
    private LoadSceneWithParameters loader;

    public Dictionary<ulong, int> cardWithValue = new Dictionary<ulong, int>();



    Boolean gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
        loader = new LoadSceneWithParameters();
        Random randObj = new Random();
        bool found;
        cards = GameObject.FindGameObjectsWithTag("Card").ToList();
        int[] values = new int[cards.Count];
        for (int i = 0; i < values.Length; i += 2)
        {
            found = false;
            int rand = randObj.Next(1, cardSprites.Count) - 1;

            for (int y = 0; y < values.Length; y++)
            {
                if (values[y] == rand)
                {
                    found = true;
                    break;
                }

            }
            if (found)
            {
                i -= 2;
            }
            else if (!found)
            {
                values[i] = rand;
                values[i + 1] = rand;
            }





        }
        Random rnd = new Random();
        int[] mixedValues = values.OrderBy(x => rnd.Next()).ToArray();
        int index = 0;
        foreach (var card in cards)
        {
            cardWithValue.Add((ulong)card.GetInstanceID(), mixedValues[index]);
            Instantiate(cardSprites[mixedValues[index]], card.transform.position, Quaternion.identity);
            index++;
        }


    }



    // Update is called once per frame
    void Update()
    {

        if (!gameOver)
        {
            if (GameObject.FindGameObjectsWithTag("Card").ToList().Count <= 0)
            {
                Debug.Log("The level is done !");
                if (missedMatches >= 3)
                {
                    pointCount = 1;
                }
                if (missedMatches == 2)
                {
                    pointCount = 2;
                }
                if (missedMatches < 2)
                {
                    pointCount = 3;
                }

                string currentScene = SceneManager.GetActiveScene().name;
                Debug.Log("Scene " + currentScene);

                switch (currentScene)
                {
                    case "MemoryGame1":
                        Constants.cardsMinigame1Points = pointCount;
                        Debug.Log("Level 1 and nb points: " + Constants.cardsMinigame1Points);
                        loader.LoadSceneWithParams(pointCount, "MC1");
                        break;
                    case "MemoryGame2":
                        Constants.cardsMinigame2Points = pointCount;
                        Debug.Log("Level 1 and nb points: " + Constants.cardsMinigame2Points);
                        loader.LoadSceneWithParams(pointCount, "MC2");
                        break;
                    case "MemoryGame3":
                        Constants.cardsMinigame3Points = pointCount;
                        Debug.Log("Level 1 and nb points: " + Constants.cardsMinigame3Points);
                        loader.LoadSceneWithParams(pointCount, "MC3");
                        break;
                    default:
                        Debug.Log("Unknown scene: " + currentScene);
                        break;
                }

            }


            if (Input.GetMouseButtonDown((int)MouseButton.Left) && !isInvoked)
            {

                Vector3 cardRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D clickedCard = Physics2D.Raycast(cardRay, Vector2.zero);

                if (clickedCard.transform.gameObject != null && clickedCard.transform.gameObject.CompareTag("Card"))
                {
                    Debug.Log(cardWithValue[(ulong)clickedCard.transform.gameObject.GetInstanceID()]);

                    clickedCard.transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;

                    if (!firstCard)
                    {
                        cardValues.Push(cardWithValue[(ulong)clickedCard.transform.gameObject.GetInstanceID()]);
                        selectedCards.Push(clickedCard.transform.gameObject);
                        firstCard = true;
                    }
                    else if (firstCard)
                    {
                        cardValues.Push(cardWithValue[(ulong)clickedCard.transform.gameObject.GetInstanceID()]);
                        selectedCards.Push(clickedCard.transform.gameObject);

                        isInvoked = true;
                        Invoke("CheckCards", seconds);


                    }

                }



            }
        }
    }



    private void CheckCards()
    {
        if (cardValues.Distinct().Count() == 1)
        {
            Debug.Log("They are both the same");
            while (selectedCards.Count > 0)
            {
                GameObject go = selectedCards.Pop();
                Destroy(go);
            }
            cardValues.Clear();
            selectedCards.Clear();
            firstCard = false;
        }
        else
        {
            Debug.Log("They are not the same");
            missedMatches++;
            while (selectedCards.Count > 0)
            {
                GameObject go = selectedCards.Pop();
                go.GetComponent<SpriteRenderer>().enabled = true;
            }
            cardValues.Clear();
            selectedCards.Clear();

            firstCard = false;
        }

        isInvoked = false;

    }


    private IEnumerator Countdown()
    {
        while (timeForLevel > 0)
        {
            timeForLevel--;
            cardTextCounter.text = $"Time remaining : {timeForLevel}";
            yield return new WaitForSecondsRealtime(1);
        }
        gameOver = true;
        Debug.Log("Game over ");
        //Make canvas appear here
        cardTextCounter.alignment = TextAnchor.MiddleCenter;
        cardTextCounter.text = $"You lose, Press SPACE to Retry!";

        yield return null;
    }


}
