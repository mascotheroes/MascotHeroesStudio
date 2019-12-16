using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Patrol patrolPath;

    [SerializeField] float speed;
    [SerializeField] float delayAtEndOfPath;

    //apparently setting the parent to null reset the position no matter what i do so im doing this for now
    public Movement player;

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
        Vector3 movement = Vector3.MoveTowards(transform.position, patrolPath.currentNode.position, speed * Time.deltaTime);
        
        if(player != null)
        {
           // Debug.Log(movement - transform.position);
            player.gameObject.transform.position += movement - transform.position;
        }
        transform.position = movement;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement m = collision.gameObject.GetComponent<Movement>();
        if (m != null)
        {
            //collision.gameObject.transform.SetParent(gameObject.transform);
            player = m;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Movement m = collision.gameObject.GetComponent<Movement>();
        if (m != null)
        {
            player = null;
            //Vector3 pos = collision.gameObject.transform.TransformPoint(collision.transform.position);
            //Debug.Log(pos);

            //collision.gameObject.transform.parent = null;
            //collision.transform.position = pos;
         
        }
    }
}
