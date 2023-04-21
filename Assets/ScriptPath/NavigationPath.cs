using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationPath : MonoBehaviour
{
    public int totalLevels;
    public KeyCode nextLevelKey = KeyCode.RightArrow;
    public KeyCode previousLevelKey = KeyCode.LeftArrow;
    public float moveSpeed = 5f;

    [SerializeField]
    public List<PathObject> waypointGameObjects = new List<PathObject>();
    
    private int level = 1;
    private bool isTransitioning = false;
    private Vector3 targetPosition;

    private void Start()
    {
        // Composition of the full path
        waypointGameObjects.Add(new PathObject(new Vector2(6.42f, -8.84f), WayPointType.Level, 1));
        waypointGameObjects.Add(new PathObject(new Vector2(8.53f, -8.43f), WayPointType.PathWay, null));
        waypointGameObjects.Add(new PathObject(new Vector2(8.34f, -2.67f), WayPointType.Level, 2));
        waypointGameObjects.Add(new PathObject(new Vector2(5.98f, -1.29f), WayPointType.PathWay, null));
        waypointGameObjects.Add(new PathObject(new Vector2(-0.34f, -1.4f), WayPointType.PathWay, null));
        waypointGameObjects.Add(new PathObject(new Vector2(-0.46f, 2.54f), WayPointType.PathWay, null));
        waypointGameObjects.Add(new PathObject(new Vector2(6.23f, 3.31f), WayPointType.Level, 3));

        // Count of all nodes with a waypointtype of "level".
        totalLevels = waypointGameObjects.Count(l => l.type == WayPointType.Level);

        // Start at the bottom.
        transform.position = waypointGameObjects[0].waypoint;
    }

    private void Update()
    {
        if (!isTransitioning && Input.GetKeyDown(nextLevelKey))
        {
            int newlevel = level;
            newlevel++;

            if (newlevel > totalLevels)
            {
                newlevel = totalLevels;
            }
            else
            {
                StartCoroutine(TransitionToLevel(level, newlevel));
            }
        }
        else if (!isTransitioning && Input.GetKeyDown(previousLevelKey))
        {
            int newlevel = level;
            newlevel--;

            if (newlevel < 1)
            {
                newlevel = 1;
            }
            else
            {
                StartCoroutine(TransitionToLevel(level, newlevel));
            }
        }
    }

    private IEnumerator TransitionToLevel(int currentlevel, int newlevel)
    {
        isTransitioning = true;

        // This is the range of movemovent from level X to level Y.        
        List<PathObject> partPath = new List<PathObject>();

        // Get all the elements from the list between level X and Y forward or reverse.
        int start_index = waypointGameObjects.FindIndex(o => o.level == currentlevel);
        int end_index = waypointGameObjects.FindIndex(o => o.level == newlevel);
        partPath = waypointGameObjects.Skip(Math.Min(start_index, end_index)).Take(Math.Abs(start_index - end_index) + 1).ToList();

        // If moving backwards, reverse the nodes we found.
        if (currentlevel > newlevel)
        {
            partPath.Reverse();
        }

        // Remove the current node, since we don't want to go there.
        partPath.RemoveAt(0);

        foreach (var p in partPath)
        {
            Vector3 startPosition = transform.position;
            targetPosition = p.waypoint;

            while (transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }

        isTransitioning = false;
        level = newlevel;
        yield return null;
    }
}

public enum WayPointType
{
    Level,
    PathWay
}

public class PathObject
{
    public PathObject(Vector2 wp, WayPointType wpt, int? l)
    {
        this.waypoint = wp;
        this.type = wpt;
        this.level = l;
    }

    public Vector2 waypoint;
    public WayPointType type;
    public int? level;
}
