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

        if (aiScript.CanAttackTarget())
        {
            //Goto Attack State
        }
        else if (!aiScript.CanSeeTarget())
        {
            //Go to idle state 
        }

        //Keep chasing until edge is detected
    }

    public override void Exit()
    {
        base.Exit();
    }
}
