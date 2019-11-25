using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    //replace with eventsystem
    [SerializeField] CameraController camaeraController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Pawn>() != null)
        {
            camaeraController.ChangeToStaticCam(transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Pawn>() != null)
        {
            camaeraController.ChangeToFollowPlayer();
        }
    }
}
