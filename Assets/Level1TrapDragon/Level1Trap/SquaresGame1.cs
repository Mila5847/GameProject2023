using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Squares : MonoBehaviour
{
    public GameObject squarePrefab;
    public int numRows = 6;
    public int numColumns = 6;
    public float rowSpacing = 1.5f;
    public float colSpacing = 1.5f;

    private GameObject[,] squares;
    public GameObject dragonPrefab;
    private GameObject dragon;

    private int redSquares;
    private int pointCount;

    void Start()
    {
        // Calculate total width and height of grid based on number of rows, columns, and spacing
        float totalWidth = (numColumns - 1) * colSpacing;
        float totalHeight = (numRows - 1) * rowSpacing;

        // Calculate starting position of grid based on total width and height
        Vector3 startPosition = new Vector3(-totalWidth / 2f, totalHeight / 2f, 0);

        squares = new GameObject[numRows, numColumns];

        // Loop through rows and columns to create squares and position them evenly
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                GameObject square = Instantiate(squarePrefab, transform);
                float x = startPosition.x + col * colSpacing;
                float y = startPosition.y - row * rowSpacing;
                square.transform.position = new Vector3(x, y, 0);

                // Add a box collider component to the square
                BoxCollider2D collider = square.AddComponent<BoxCollider2D>();
                collider.isTrigger = true;

                squares[row, col] = square;
            }
        }

        // Create the dragon and position it on a random square
        dragon = Instantiate(dragonPrefab, transform);
        int randomRow = numRows/2;
        int randomCol = numColumns/2;
        dragon.transform.position = squares[randomRow, randomCol].transform.position;
    }

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position to detect any colliders
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            // If a collider was hit and it's a square, change its color and move the dragon to a random adjacent square that is not red
            if (hit.collider != null && hit.collider.CompareTag("Square"))
            {
                GameObject square = hit.collider.gameObject;
                Renderer renderer = square.GetComponent<Renderer>();
                if (renderer.material.color != Color.red)
                {
                    renderer.material.color = Color.red;
                    redSquares++;

                    // Check if the dragon is surrounded by red squares
                    if (IsDragonSurroundedByRedSquares())
                    {
                        if (redSquares <= 10)
                        {
                            Debug.Log("nb squares " + redSquares);
                            pointCount = 3;

                        }else if(redSquares > 10 && redSquares <= 20)
                        {
                            Debug.Log("nb squares " + redSquares);
                            pointCount = 2;
                        }
                        else
                        {
                            pointCount = 1;
                        }

                        Debug.Log("The dragon is surrounded by red squares!");
                        string currentScene = SceneManager.GetActiveScene().name;
                        Debug.Log("Scene " + currentScene);

                        switch (currentScene)
                        {
                            case "DragonGameSc1":
                                StarsManager.trapDragonMinigame1Points = pointCount;
                                Debug.Log("Level 1 and nb points: " + StarsManager.trapDragonMinigame1Points);
                                break;
                            case "DragonGameSc2":
                                StarsManager.trapDragonMinigame2Points = pointCount;
                                Debug.Log("Level 2 and nb points: " + StarsManager.trapDragonMinigame2Points);
                                break;
                            /*case "":
                                StarsManager.trapDragonMinigame3Points = pointCount;
                                Debug.Log("Level 3 and nb points " + StarsManager.trapDragonMinigame3Points);
                                StarsManager.startTime = 0;
                                //SceneManager.LoadScene("Success");
                                break;*/
                            default:
                                Debug.Log("Unknown scene: " + currentScene);
                                break;
                        }
           
                    }
                    else
                    {
                        MoveDragonToRandomSquare();
                    }
                }
            }
        }
    }

    bool IsDragonSurroundedByRedSquares()
    {
        int dragonRow = 0;
        int dragonCol = 0;

        // Find the current row and column of the dragon
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                if (squares[row, col].transform.position == dragon.transform.position)
                {
                    dragonRow = row;
                    dragonCol = col;
                    break;
                }
            }
        }

        // Check if all adjacent squares are red
        if (dragonRow > 0 && squares[dragonRow - 1, dragonCol].GetComponent<Renderer>().material.color != Color.red)
        {
            return false;
        }
        if (dragonRow < numRows - 1 && squares[dragonRow + 1, dragonCol].GetComponent<Renderer>().material.color != Color.red)
        {
            return false;
        }
        if (dragonCol > 0 && squares[dragonRow, dragonCol - 1].GetComponent<Renderer>().material.color != Color.red)
        {
            return false;
        }
        if (dragonCol < numColumns - 1 && squares[dragonRow, dragonCol + 1].GetComponent<Renderer>().material.color != Color.red)
        {
            return false;
        }

        return true;
    }


    void MoveDragonToRandomSquare()
    {
        int dragonRow = 0;
        int dragonCol = 0;

        // Find the current row and column of the dragon
        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                if (squares[row, col].transform.position == dragon.transform.position)
                {
                    dragonRow = row;
                    dragonCol = col;
                    break;
                }
            }
        }

        // Find all adjacent squares that are not red
        List<GameObject> validSquares = new List<GameObject>();

        if (dragonRow > 0 && squares[dragonRow - 1, dragonCol].GetComponent<Renderer>().material.color != Color.red)
        {
            validSquares.Add(squares[dragonRow - 1, dragonCol]);
        }
        if (dragonRow < numRows - 1 && squares[dragonRow + 1, dragonCol].GetComponent<Renderer>().material.color != Color.red)
        {
            validSquares.Add(squares[dragonRow + 1, dragonCol]);
        }
        if (dragonCol > 0 && squares[dragonRow, dragonCol - 1].GetComponent<Renderer>().material.color != Color.red)
        {
            validSquares.Add(squares[dragonRow, dragonCol - 1]);
        }
        if (dragonCol < numColumns - 1 && squares[dragonRow, dragonCol + 1].GetComponent<Renderer>().material.color != Color.red)
        {
            validSquares.Add(squares[dragonRow, dragonCol + 1]);
        }

        // If there are no valid squares, don't move the dragon
        if (validSquares.Count == 0)
        {
            return;
        }

        // If there's only one valid square, move the dragon to it
        if (validSquares.Count == 1)
        {
            dragon.transform.position = validSquares[0].transform.position;
            return;
        }

        // Otherwise, choose a random valid square and move the dragon to it
        int randomIndex = Random.Range(0, validSquares.Count);
        dragon.transform.position = validSquares[randomIndex].transform.position;
    }
}
