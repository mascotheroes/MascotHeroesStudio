using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTopButton : Controller
{
    [Range(0,1)] public float jumpScreenPercentagefromTop;

    int ScreenWidth;
    int ScreenHeight;
    // Start is called before the first frame update
    void Start()
    {
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touches.Length > 0)
        {
            //bools so if multiple touches are on one sideit still does it once
            bool moveRight = false;
            bool moveLeft = false;
            bool jump = false;
           
            for (int i = 0; i < Input.touches.Length; i++)
            {
                
                if((Input.touches[i].position.x < ScreenWidth / 2) 
                    &&!moveLeft
                    &&(Input.touches[i].position.y < ScreenHeight *jumpScreenPercentagefromTop))
                {
                    pawn.Move(-1);
                    moveLeft = true;
                }
                else if((Input.touches[i].position.x > ScreenWidth / 2)
                    && !moveRight
                    && (Input.touches[i].position.y < ScreenHeight * jumpScreenPercentagefromTop))
                {
                    pawn.Move(1);
                    moveRight = true;
                }

                if (Input.touches[i].position.y > ScreenHeight * jumpScreenPercentagefromTop)
                {
                    pawn.Jump();
                    jump = true;
                }
            }
 
        }
    }
}
