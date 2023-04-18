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

    public Vector3 waypoint1;
    public Vector3 waypoint2;
    public Vector3 waypoint3;
    public Vector3 waypoint4;

    public GameObject waypoint1GameObject;


    private int currentLevelIndex = 1;
    private bool isTransitioning = false;
    private Vector3 targetPosition;

    private void Start()
    {
        StartCoroutine(TransitionToLevel(currentLevelIndex));
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
        waypoint1GameObject = GameObject.FindWithTag("LevelPath 1");
        waypoint1 = waypoint1GameObject.transform.position;

        Vector3 startPosition = transform.position;
        float elapsedTime = 0.0f;

        while (elapsedTime < transitionDuration)
        {
            if (currentLevelIndex == 2 && levelIndex == 2 || currentLevelIndex == 1 && levelIndex == 1) // from level 1 to 2
            {
                // Move towards waypoint1 first
                Vector3 waypoint1Position = waypoint1;
                float distanceToWaypoint1 = Vector3.Distance(startPosition, waypoint1Position);
                float distanceToTarget = Vector3.Distance(waypoint1Position, targetPosition);
                float currentLerpTime = elapsedTime / transitionDuration;
                float lerpTimeToWaypoint1 = distanceToWaypoint1 / (distanceToWaypoint1 + distanceToTarget);
                float lerpTimeToTarget = 1f - lerpTimeToWaypoint1;
                if (currentLerpTime < lerpTimeToWaypoint1)
                {
                    // Move towards waypoint1
                    transform.position = Vector3.Lerp(startPosition, waypoint1Position, currentLerpTime / lerpTimeToWaypoint1);
                }
                else
                {
                    // Move towards targetPosition
                    transform.position = Vector3.Lerp(waypoint1Position, targetPosition, (currentLerpTime - lerpTimeToWaypoint1) / lerpTimeToTarget);
                }
                elapsedTime += Time.deltaTime;
            }
            else
            {
                // Move towards targetPosition in a straight line
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / transitionDuration);
                elapsedTime += Time.deltaTime;
            }

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
