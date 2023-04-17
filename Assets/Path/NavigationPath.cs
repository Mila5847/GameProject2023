using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationPath : MonoBehaviour
{
    public int totalLevels = 3;
    public KeyCode nextLevelKey = KeyCode.RightArrow;
    public KeyCode previousLevelKey = KeyCode.LeftArrow;
    public float transitionDuration = 4.5f;

    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject waypoint3;
    public GameObject waypoint4;


    private int currentLevelIndex = 1;
    private bool isTransitioning = false;
    private Vector3 targetPosition;

    private void Start()
    {
        StartCoroutine(TransitionToLevel(1));
    }


    private void Update()
    {
        if (!isTransitioning && Input.GetKeyDown(nextLevelKey))
        {
            currentLevelIndex++;
            if (currentLevelIndex > totalLevels)
            {
                currentLevelIndex = totalLevels;
            }
            else
            {
                StartCoroutine(TransitionToLevel(currentLevelIndex));
            }
        }
        else if (!isTransitioning && Input.GetKeyDown(previousLevelKey))
        {
            currentLevelIndex--;
            if (currentLevelIndex < 1)
            {
                currentLevelIndex = 1;
            }
            else
            {
                StartCoroutine(TransitionToLevel(currentLevelIndex));
            }
        }
    }

    private IEnumerator TransitionToLevel(int levelIndex)
    {
        isTransitioning = true;
        targetPosition = GetLevelPosition(levelIndex);
        Vector3 startPosition = transform.position;
        float elapsedTime = 0.0f;

        while (elapsedTime < transitionDuration)
        {
            if (currentLevelIndex == 1 && levelIndex == 2) // from level 1 to 2
            {
               
            }
            else if (currentLevelIndex == 2 && levelIndex == 3) // from level 2 to 3
            {
                
            }
            else if (currentLevelIndex == 3 && levelIndex == 2) // from level 3 to 2
            {
               
            }

            //transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / transitionDuration);
            //elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isTransitioning = false;
    }

    private Vector3 GetLevelPosition(int levelIndex)
    {
        // Find the GameObject with the tag "Level" followed by the levelIndex
        GameObject level = GameObject.FindWithTag("Level " + levelIndex);

        // Return the position of the level GameObject
        return level.transform.position;
    }
}
