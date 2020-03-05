using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3(0,0,-10);

    Camera camera;

    enum MovementSate
    {
        FollowPlayer,
        Static,
        None
    }
    MovementSate currentState;

    Vector3 staticCamTarget;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        currentState = MovementSate.FollowPlayer;

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case MovementSate.FollowPlayer:
                FollowPlayer();
                break;
            case MovementSate.Static:
                StaticCamera();
                break;
            case MovementSate.None:
                break;
            default:
                break;
        }
    }

   
    private void FollowPlayer()
    {
        //transform.position = GameManager.instance.player.pawn.transform.position + offset;
    }

    public void ChangeToFollowPlayer()
    {
        currentState = MovementSate.FollowPlayer;
    }

    public void ChangeToStaticCam(Vector3 target)
    {
        staticCamTarget = target;
        currentState = MovementSate.Static;
    }
    private void StaticCamera()
    {
        transform.position = staticCamTarget + offset;
    }

}
