using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_AI : Controller
{
    [SerializeField] Patrol patrol;
    //[SerializeField] GameObject patrolNodeHolder;

    // Start is called before the first frame update
    void Start()
    {
        //patrol.patrolNodes.Clear();
        //patrol.patrolNodes.AddRange(patrolNodeHolder.GetComponentsInChildren<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        if (patrol.CheckCloseEnough(pawn.transform.position))
        {
            patrol.IncrimentPatrolNode();
        }
        if (patrol.currentNode.position.x - pawn.transform.position.x > 0)
        {
            pawn.Move(1);
        }
        else
        {
            pawn.Move(-1);
        }
    }
}
