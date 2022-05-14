using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : States
{
    public ChaseState(EnemyAI _aiScript, GameObject _npc) : base(_aiScript, _npc)
    {
        State = STATE.CHASE;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        //Keep chasing until edge is detected
        if (aiScript.canMove() && aiScript.CanSeeTarget())
        {
            aiScript.MoveTowardPlayer();
        }


        if (aiScript.CanAttackTarget())
        {
            //Goto Attack State
            nextState = new AttackState(aiScript, npc);
            Stage = STAGE.EXIT;
        }
        else if (!aiScript.CanSeeTarget())
        {
            //Go to idle state 
            nextState = new IdleState(aiScript, npc);
            Stage = STAGE.EXIT;
        }


    }

    public override void Exit()
    {
        //TODO : handle the transition from patrol to chase state so that it doesn't fall of the edge
        if (nextState.State == STATE.IDLE)
            aiScript.Stop();
        base.Exit();
    }
}
