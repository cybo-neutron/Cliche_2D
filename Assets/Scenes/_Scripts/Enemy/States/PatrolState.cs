using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : States
{

    int currIndex;
    int totalWaypoints = 2;

    public PatrolState(EnemyAI _aiScript, GameObject _npc) : base(_aiScript, _npc)
    {
        State = STATE.PATROL;
        totalWaypoints = aiScript.env.waypoints.Length;
    }

    public override void Enter()
    {
        // Debug.Log("Patrol State");
        base.Enter();

        //Find the closest waypoint as targetWaypoint
        currIndex = findClosestWayPoint();

    }


    public override void Update()
    {
        base.Update();

        if (aiScript.CanSeeTarget())
        {
            //Go to chase state
            // Debug.Log("Can see target now");
            nextState = new ChaseState(aiScript, npc);
            Stage = STAGE.EXIT;
        }


        //If current waypoint is reached update the it to nextwaypoint
        handleWayPoint();

        //Keep patrolling b/w the waypoints
        aiScript.MoveTowards(aiScript.env.waypoints[currIndex]);
    }

    public override void Exit()
    {
        base.Exit();
    }

    int findClosestWayPoint()
    {
        int closestIndex = 0;
        float closestDistance = Mathf.Infinity;
        for (int i = 0; i < totalWaypoints; i++)
        {
            float currDist = Vector2.Distance(npc.transform.position, aiScript.env.waypoints[i].position);
            if (currDist < closestDistance)
            {
                closestDistance = currDist;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

    void handleWayPoint()
    {
        if (Vector2.Distance(npc.transform.position, aiScript.env.waypoints[currIndex].transform.position) < 0.1f)
        {
            nextWayPoint();
        }
        //TODO: come with a better implementation for edge detection and flipping the player
        if (!aiScript.canMove())
        {
            nextWayPoint();
            // aiScript.Flip();
        }
    }

    void nextWayPoint()
    {
        currIndex = (currIndex + 1) % totalWaypoints;
    }
}
