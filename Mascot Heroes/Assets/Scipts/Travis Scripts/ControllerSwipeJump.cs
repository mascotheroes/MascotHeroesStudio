using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSwipeJump : Controller
{
    public float swipeSpeed;
    int ScreenWidth = Screen.width;

    int LastFingerIndex = -1;
    public List<Touch> touchesInOrder = new List<Touch>();
    public void Start()
    {
        GameManager.instance.player = this;   
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touches.Length > 0)
        {
           // Debug.Log(Input.touches[Input.touches.Length-1].position);
            //bools so if multiple touches are on one sideit still does it once
            bool moveRight = false;
            bool moveLeft = false;

            for (int i = 0; i < Input.touches.Length; i++)
            {

                if(Input.touches[i].phase == TouchPhase.Began)
                {
                    touchesInOrder.Add(Input.touches[i]);
                }
                else if(Input.touches[i].phase == TouchPhase.Ended)
                {
                    touchesInOrder.Remove(Input.touches[i]);
                }

                if(touchesInOrder[touchesInOrder.Count-1].position.x < ScreenWidth / 2 && !moveLeft )
                {
                    pawn.Move(-1);
                    moveLeft = true;
                }
                else if(touchesInOrder[touchesInOrder.Count - 1].position.x >= ScreenWidth / 2 && !moveRight)
                {
                    pawn.Move(1);
                    moveRight = true;
                }

                //if ((Input.touches[i].position.x < ScreenWidth / 2)
                //    && !moveLeft)
                //{
                //    Debug.Log((Input.touches[i].fingerId));
                //    pawn.Move(-1);
                //    moveLeft = true;
                //}
                //else if ((Input.touches[i].position.x > ScreenWidth / 2)
                //    && !moveRight)
                //{
                //    Debug.Log((Input.touches[i].fingerId));
                //    pawn.Move(1);
                //    moveRight = true;
                //}
            }

        }
    }
}
