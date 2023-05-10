using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoController : MonoBehaviour
{
    public Canvas canvas; 

    public void CanvasOn()
    {
        canvas.enabled = true; 
    }

    public void CanvasOff()
    {
        canvas.enabled = false; 
    }
}
