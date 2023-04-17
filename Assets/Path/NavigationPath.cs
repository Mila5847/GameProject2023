using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationPath : MonoBehaviour
{
    public int totalLevels = 3;
    public KeyCode nextLevelKey = KeyCode.RightArrow;
    public KeyCode previousLevelKey = KeyCode.LeftArrow;
    public float transitionDuration = 4.5f;

    private int currentLevelIndex = 1;
    private bool isTransitioning = false;
    private Vector3 targetPosition;

    private void Start()
    {
        // Set the initial position to the position of the first level
        transform.position = GetLevelPosition(currentLevelIndex);
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
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
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
