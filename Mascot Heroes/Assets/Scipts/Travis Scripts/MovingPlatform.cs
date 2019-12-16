using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Patrol patrolPath;

    [SerializeField] float speed;
    [SerializeField] float delayAtEndOfPath;

    enum PlatformStates
    {
        Wait,
        Patroling
    }

    PlatformStates currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlatformStates.Wait;
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case PlatformStates.Wait:
                break;
            case PlatformStates.Patroling:
                Patrol();
                break;
        }
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPath.currentNode.position, speed * Time.deltaTime);
        if (patrolPath.CheckCloseEnough(transform.position))
        {
            if(patrolPath.IsAtEndOfRoute || patrolPath.IsAtBeginningOfRoute)
            {
                currentState = PlatformStates.Wait;
                
                StartCoroutine( Delay());
                
            }
            else
            {
                patrolPath.IncrimentPatrolNode();
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayAtEndOfPath);
       
        currentState = PlatformStates.Patroling;

        patrolPath.IncrimentPatrolNode();

    }
}
