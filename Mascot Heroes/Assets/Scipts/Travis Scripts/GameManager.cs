using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ControllerSwipeJump player;
    public GameObject playerControllerObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SwapPlayerScript()
    {
        ControllerSwipeJump jump = playerControllerObject.GetComponent<ControllerSwipeJump>();
        ControllerTopButton top = playerControllerObject.GetComponent<ControllerTopButton>();

        jump.enabled = !jump.enabled;
        top.enabled = !top.enabled;
    }
}
