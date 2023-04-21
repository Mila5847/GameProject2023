using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class CardGame1 : MonoBehaviour
{

    public List<GameObject> cards;

    private bool show = false;

    private int seconds = 2;


    public RaycastHit2D clicked;

    public Dictionary<ulong, int> cardWithValue = new Dictionary<ulong, int>();
    // Start is called before the first frame update
    void Start()
    {
        Random randObj = new Random();
        bool found;
        cards = GameObject.FindGameObjectsWithTag("Card").ToList();
        int[] values = new int[cards.Count];
        for (int i = 0; i < values.Length; i += 2)
        {
            found = false;
            int rand = randObj.Next(1, cards.Count + 1);

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
            index++;
        }

        foreach (KeyValuePair<ulong, int> card in cardWithValue)
        {
            Debug.Log($"Key: {card.Key}, Value: {card.Value}");
        }

    }



    // Update is called once per frame
    void Update()
    {

    }


}
