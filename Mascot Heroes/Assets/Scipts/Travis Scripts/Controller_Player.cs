using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player : Controller
{
    private bool movingRight;
    private bool movingLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            pawn.Move(1);
        }
        else if (movingLeft)
        {
            pawn.Move(-1);
        }
    }
    //stuff from freds scripts
    public void SetMoveRight()
    {
        movingRight = true;
        movingLeft = false;
    }
    public void SetMoveLeft()
    {
        movingLeft = true;
        movingRight = false;
    }
    public void StopLeftMovement()
    {
        movingLeft = false;
    }
    public void StopRightMovement()
    {
        movingRight = false;
    }
    public void Jump()
    {
        pawn.Jump();
    }
}
