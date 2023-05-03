using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    public float speed;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    private Rigidbody2D rb2d;


    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.position - lastPosition;
        var localDirection = transform.InverseTransformDirection(direction);
        lastPosition = transform.position;

        animator.speed = 1;
        float val_x = localDirection.x;
        float val_y = localDirection.y;
        float abs_val_x = Math.Abs(val_x);
        float abs_val_y = Math.Abs(val_y);



        if (val_x < 0 && abs_val_y < abs_val_x) //then set direction to 3
        {
            animator.SetInteger("Direction", (int)MoveDirectionPlayer.LEFT);
        }
        else if (val_x > 0 && abs_val_y < abs_val_x) //then set direction to 4
        {
            animator.SetInteger("Direction", (int)MoveDirectionPlayer.RIGHT);
        }
        else if (val_y < 0 && abs_val_y > abs_val_x)//then set direction to 2
        {
            animator.SetInteger("Direction", (int)MoveDirectionPlayer.DOWN);
        }
        else if (val_y > 0 && abs_val_y > abs_val_x) //then set direction to 1
        {
            animator.SetInteger("Direction", (int)MoveDirectionPlayer.UP);
        }
        else
        {

            animator.speed = 0;

        }

        // step 3 add rb2d.moveposition
        Vector3 playerPosition = transform.position += new Vector3(val_x, val_y, 0).normalized * speed * Time.deltaTime;

    }
}

public enum MoveDirectionPlayer
{
    NONE = 0,
    UP = 1,
    DOWN = 2,
    LEFT = 3,
    RIGHT = 4
}
