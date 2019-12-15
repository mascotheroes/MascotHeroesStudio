using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Patrol
{
    [SerializeField] List<Transform> patrolNodes;

    public enum PatrolType
    {
        Loop,
        BackAndForth
    }
    public PatrolType patrolType;

    [Tooltip("True = Goes throught the patrol nodes in order in the patrol nodes list " +
    "False = Goes through in reverse order")]
    public bool Direction = true;

    [SerializeField] float closeEnoughDistance;

    public Transform currentNode
    {
        get
        {
            return patrolNodes[currentNodeIndex];
        }
        //private set
        //{
        //    currentNode = value;
        //}
    }

    public bool HasPatrolPoints
    {
        get { return patrolNodes.Count > 0; }

    }

    public bool IsAtBeginningOfRoute
    {
        get
        {
            return currentNodeIndex == 0;
        }
       
    }

    public bool IsAtEndOfRoute
    {
        get
        {
            return currentNodeIndex == patrolNodes.Count-1;
        }

    }

    int currentNodeIndex = 0;

    public void IncrimentPatrolNode()
    {
        if (Direction)
        {
            currentNodeIndex++;

            if (currentNodeIndex >= patrolNodes.Count)
            {

                if (patrolType == PatrolType.Loop)
                {
                    currentNodeIndex = 0;
                }
                else if (patrolType == PatrolType.BackAndForth)
                {
                    Direction = false;
                    //-1 is the last node -2 is the one before the last since we want to tuen around and go the other direction
                    currentNodeIndex = patrolNodes.Count - 2;
                }
            }
        }
        else
        {
            
            if (currentNodeIndex <= 0)
            {
                Debug.Log("currentNodeIndex <= 0");
                if (patrolType == PatrolType.Loop)
                {
                    currentNodeIndex = patrolNodes.Count-1;
                }
                else if (patrolType == PatrolType.BackAndForth)
                {
                    Direction = true;
                    //0 is the last node 1 is the one before the last since we want to turn around and go the other direction
                    currentNodeIndex = 1;
                }
            }
            currentNodeIndex--;

        }
    }

    public bool CheckCloseEnough(Vector3 position)
    {
        return Vector3.Distance(position, currentNode.position) <= closeEnoughDistance;
    }
}
