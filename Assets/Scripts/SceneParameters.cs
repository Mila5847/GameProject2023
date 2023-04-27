using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneParameters
{
    public string level;
    public string minigameName;
    public int nbPoints;

    public SceneParameters(string level, string minigameName, int nbPoints)
    {
        this.level = level;
        this.minigameName = minigameName;
        this.nbPoints = nbPoints;

    }
}
