# GameProject2023

## Project Overview
Done throughout my second year of College in Computer Science in my Game Development with the Unity Cross-Platform Game Engine class, the
game project is developed by a team of four members (Karina, Denisa, Saif, and me (Mila)) and the help of our teacher. The project consists of three minigames involving a character trying to catch a dragon. 
Each minigame must be completed with a certain amount of stars so the user (controlling the character) can go to the next level. 

## Table of Contents
- [Project Description](#project-description)
- [Installation](#installation)
- [Set Up](#set-up)
- [Usage](#usage)
- [Features](#features)
- [Future Improvements Ideas](#improvements)
- [Acknowledgments](#acknowledgments)

<a name="project-description"></a>
## Project Description 
The story follows a brave young hero, Alex who ventures into long-abandoned ancient ruins to track down what appears to be a ferocious dragon. Through a series of trials, our young paladin gets closer and closer to catching the dragon. Through trials and tribulations, our hero and the dragon soon realize that they aren't as different as everyone makes them out to be. 
The game consists of three levels, each having three minigames, each with the goal of getting Alex closer to the dragon. The first of the minigames aims to trap the dragon. The game consists of placing rocks in a smart
way to corner the dragon. The second minigame consists of tactically maneuvering a piece of meat to the dragon to gain its trust. 
Finally, the third minigame consists of a memory game, which compares Alex’s belongings to the belongings of the dragon.
Stars are granted to the player depending on how well they completed each minigame. 
### Main Scene where the character walks
![game1](https://github.com/Mila5847/GameProject2023/assets/46633364/7abac67f-90d6-4c8a-9490-44dfc2068872)
### Character chooses a level
![image](https://github.com/Mila5847/GameProject2023/assets/46633364/874ff84b-4223-4682-959a-7aaa3b33f27c)
### Level 1 Starting status
![image](https://github.com/Mila5847/GameProject2023/assets/46633364/5beb9e8d-3d98-4185-ab76-cdae7a4cd60d)
### Trap the Dragon game
![image](https://github.com/Mila5847/GameProject2023/assets/46633364/0f9a135f-be36-414e-a4f9-0342c4c744ab)
### Game Menu
![image](https://github.com/Mila5847/GameProject2023/assets/46633364/eb7762d7-2dfd-42d7-9397-21a9da61d742)
### Victory scene
![image](https://github.com/Mila5847/GameProject2023/assets/46633364/ae39636d-78c6-4b58-a435-cc9201380e5f)
### Feed the Dragon game 
![image](https://github.com/Mila5847/GameProject2023/assets/46633364/40b615dd-2c7c-491e-8370-7ee2cb8789ef)
### Game over scene
![image](https://github.com/Mila5847/GameProject2023/assets/46633364/e31a7932-ddac-44eb-a1ae-93e4b873cf75)
### Matching cards game
![image](https://github.com/Mila5847/GameProject2023/assets/46633364/03516596-f182-48c1-9c5e-ebd2a4dfd630)
### Level 1 Completed Status
![image](https://github.com/Mila5847/GameProject2023/assets/46633364/2d4e2e8c-673b-4df5-9b8b-222136c1f427)
### Main Scene Updated with Star
![image](https://github.com/Mila5847/GameProject2023/assets/46633364/ea0763f5-9102-4d14-a859-c3cbcd93890f)

<a name="installation"></a>
## Installation 
1. Clone the repository
2. Navigate to the project directory
3. Install the editor version 2022.2.13f1

<a name="set-up"></a>
### Set Up

#### Platform used
The Unity platform provides a "Scene" view which allows you to visually construct and edit your scenes. You can add and position objects,
adjust their properties, set up lighting and cameras, and define the overall layout and composition of your game world. The platform also
provides the active scene that is currently being played or simulated in the Unity editor or during the actual gameplay. 
When you press the "Play" button in the Unity editor, the Game scene is created, and your game starts running in the game window or on 
the target platform.

<a name="usage"></a>
## Usage
This game is developed for entertainment purposes. The completion of each level requires the use of critical thinking. The game
is a great way to exercise logic, it also provides the chance to improve by replaying the minigames and trying new tactics.

<a name="features"></a>
## Features 
- The game provides a user-friendly environment that the player can explore and interact with (buttons, menu settings)
- The player has control over the game's settings (volume/mute, retry level, go back to menu)
- The player can go back to a level at any time.
- The player's performance is saved throughout the game with the star system.

<a name="difficulties"></a>
## Difficulties
At first, we had difficulty making the character move from one level to another. We had to set the position for each level on the map,
on the main scene. However, the background is made of multiple layers, and we had to use tilemaps to set the levels in specific places where they can be accessed. To make the character move from one level to another, Karina and our teacher created this code:
```c#
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
        waypointGameObjects.Add(new PathObject(transform.position, WayPointType.PathWay, null)); // Add new waypoint at player's starting position
        waypointGameObjects.Add(new PathObject(new Vector2(6.42f, -8.84f), WayPointType.Level, 1));
        waypointGameObjects.Add(new PathObject(new Vector2(6.42f, -8.84f), WayPointType.PathWay, null));
        waypointGameObjects.Add(new PathObject(new Vector2(8.53f, -8.43f), WayPointType.PathWay, null));
        waypointGameObjects.Add(new PathObject(new Vector2(8.34f, -2.67f), WayPointType.Level, 2));
        waypointGameObjects.Add(new PathObject(new Vector2(5.98f, -1.29f), WayPointType.PathWay, null));
        waypointGameObjects.Add(new PathObject(new Vector2(-0.34f, -1.4f), WayPointType.PathWay, null));
        waypointGameObjects.Add(new PathObject(new Vector2(-0.46f, 2.54f), WayPointType.PathWay, null));
        waypointGameObjects.Add(new PathObject(new Vector2(6.23f, 3.31f), WayPointType.Level, 3));

        // Count of all nodes with a waypointtype of "level".
        totalLevels = waypointGameObjects.Count(l => l.type == WayPointType.Level);

        // Transition to level 1
        StartCoroutine(TransitionToLevel(0, 1)); // 0 is the current "level", which is the new waypoint we added
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

        // This is the range of movement from level X to level Y.        
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
```
In the Start() method, we initialize the waypointGameObjects list by adding waypoints and levels in a specific order, making use of the enum created to distinguish the waypoints from the levels and the paths. The Update() method checks for keyboard input and initiates the TransitionToLevel() method when the player presses the nextLevelKey or previousLevelKey.

The TransitionToLevel() method calculates the path between the current level and the new level and moves the player along this path. This method first sets a boolean isTransitioning variable to true to show that a transition is in progress. It then determines the start and end indexes of the waypoints in the path and adds them to a new List called partPath. If the player is moving backward to a previous level, the method reverses the order of the waypoints in partPath. It then removes the current node from the path, since the player is already at that node. Finally, it iterates over each waypoint in the path, moves the player towards it using the MoveTowards method, and sets the new level when the transition is complete.

Another challenge was to make the star system with an optimized code that will work both for the stars displayed on each level status
and for the stars displayed in the main scene.
This is the code:
```
    public Transform starContainer1; // The container for the stars
    public Transform starContainer2; // The container for the stars
    public Transform starContainer3; // The container for the stars
    public GameObject starPrefab; // The prefab for the stars

    private int newScore1;
    private int newScore2;
    private int newScore3;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1Status")
        {
            newScore1 = Constants.trapDragonMinigame1Points;
            newScore2 = Constants.cutRopeMinigame1Points;
            newScore3 = Constants.cardsMinigame1Points;
        }
        else if(SceneManager.GetActiveScene().name == "Level2Status")
        {
            newScore1 = Constants.trapDragonMinigame2Points;
            newScore2 = Constants.cutRopeMinigame2Points;
            newScore3 = Constants.cardsMinigame2Points;

        }
        else if(SceneManager.GetActiveScene().name == "Level3Status")
        {
            newScore1 = Constants.trapDragonMinigame3Points;
            newScore2 = Constants.cutRopeMinigame3Points;
            newScore3 = Constants.cardsMinigame3Points;
        }
        else
        {
            newScore1 = Constants.totalPointsLevel1;
            newScore2 = Constants.totalPointsLevel2;
            newScore3 = Constants.totalPointsLevel3;
        }
            // Destroy any previous stars in the container
            foreach (Transform child in starContainer1)
            {
                Destroy(child.gameObject);
            }

            // Instantiate new stars in the container based on the score
            for (int i = 0; i < newScore1; i++)
            {
                GameObject star = Instantiate(starPrefab, starContainer1);
                star.transform.localPosition = new Vector3(i * 100f, 0f, 0f);
            }
     
            // Destroy any previous stars in the container
            foreach (Transform child in starContainer2)
            {
                Destroy(child.gameObject);
            }

            // Instantiate new stars in the container based on the score
            for (int i = 0; i < newScore2; i++)
            {
                GameObject star = Instantiate(starPrefab, starContainer2);
                star.transform.localPosition = new Vector3(i * 100f, 0f, 0f);
            }

            // Destroy any previous stars in the container
            foreach (Transform child in starContainer3)
            {
                Destroy(child.gameObject);
            }

            // Instantiate new stars in the container based on the score
            for (int i = 0; i < newScore3; i++)
            {
                GameObject star = Instantiate(starPrefab, starContainer3);
                star.transform.localPosition = new Vector3(i * 100f, 0f, 0f);
            }
      
    }
```
The script manages three containers (starContainer1, starContainer2, and starContainer3) that hold stars. Each container represents a different minigame or level. The script also has a starPrefab, which is the template for creating new stars.
The Update() function is called every frame. Depending on the active scene, the script retrieves the scores for each minigame or level and stores them in newScore1, newScore2, and newScore3. The script updates the stars in each container by first destroying any existing stars in the container. Then, it instantiates new stars in the container based on the respective score.
The number of stars created corresponds to the score obtained, and they are positioned horizontally within the container.

<a name="improvements"></a>
## Future Improvements Ideas
- I would like to make the graphics look more realistic (especially the character).
- I would like to fix a small bug on Level 2, in the Feed the Dragon game. In this game, the food (the meat) for the dragon falls on a platform that constantly moves from right to left. Then, the food is brought to the dragon by the platform. However, if the food falls on the edge of the platform, its position is instantly re-centered to the center of the platform, but I want it to stay where it initially fell.

<a name="acknowledgments"></a>
## Acknowledgments 
I would like to thank all my teammates who contributed to this project: Karina, Denisa, and Saif, and also my teacher, B. Wood, who 
fixed some big issues such as the character walking on the map where the levels are displayed.
